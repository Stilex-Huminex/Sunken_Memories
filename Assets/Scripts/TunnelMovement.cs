using System;
using UnityEngine;

public class TunnelMovement : MonoBehaviour
{
    private const float MoveSpeed = 20f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform helice;
    [SerializeField] private ParticleSystem smoke;
    private bool canMove = true;
    private float stunTimer;
    private bool hasCrashed;

    private void FixedUpdate()
    {
        var pos = transform.position;
        if (hasCrashed)
        {
            transform.position += UnityEngine.Random.insideUnitSphere * 0.1f;
        }
        if (!canMove)
        {
            stunTimer -= Time.deltaTime;
            if (!(stunTimer <= 0)) return;
            rb.drag = 20f;
            canMove = true;
            return;
        }
        var vel = rb.velocity;
        var h = Input.GetAxis("Horizontal") * MoveSpeed;
        var v = Input.GetAxis("Vertical") * MoveSpeed;
        rb.AddForce(new Vector3(h, v, 0), ForceMode.Impulse);
        helice.Rotate(Vector3.left, (float)Math.Sqrt(vel.x*vel.x + vel.y*vel.y)*0.2f + 4f, Space.Self);
        rb.velocity = Vector3.ClampMagnitude(vel, 10);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Tunnel"))
        {
            hasCrashed = true;
            smoke.Play();
            stunTimer = 1f;
            canMove = false;
            rb.drag = 3f;
            rb.AddForce(transform.InverseTransformPoint(Vector3.zero)*2f, ForceMode.VelocityChange);
        }
    }
}