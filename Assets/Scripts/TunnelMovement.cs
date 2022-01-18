using System;
using UnityEngine;

public class TunnelMovement : MonoBehaviour
{
    private const float MoveSpeed = 20f;
    public static float TravelSpeed = 0.05f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform helice;
    [SerializeField] private ParticleSystem smoke;
    private bool canMove = true;
    private float stunTimer;

    private void FixedUpdate()
    {
        if (TravelSpeed < 0.3 && stunTimer <= 0.5) TravelSpeed += 0.0005f;
        if (!canMove){

            TravelSpeed -= 0.001f;
            if (TravelSpeed < 0) TravelSpeed = 0.0005f;
            stunTimer -= Time.deltaTime;
            if (!(stunTimer <= 0))
            {
                smoke.Stop();
                return;
            }
            rb.drag = 20f;
            canMove = true;
            return;
        }
        var vel = rb.velocity;
        var h = Input.GetAxis("Horizontal") * MoveSpeed;
        var v = Input.GetAxis("Vertical") * MoveSpeed;
        rb.AddForce(new Vector3(h, v, 0), ForceMode.Impulse);
        helice.Rotate(Vector3.left, TravelSpeed*40f, Space.Self);
        rb.velocity = Vector3.ClampMagnitude(vel, 10);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Volume")) return;
        if (!canMove) return;
        smoke.Play();
        stunTimer = 1f;
        canMove = false;
        var ratio = 2f;
        TravelSpeed /= 2f;
        if (!collision.collider.CompareTag("Tunnel"))
        {
            ratio = 0.5f;
            collision.collider.enabled = false;
        }
        rb.drag = 3f;
        rb.AddForce(transform.InverseTransformPoint(Vector3.zero)*ratio, ForceMode.VelocityChange);
    }
}