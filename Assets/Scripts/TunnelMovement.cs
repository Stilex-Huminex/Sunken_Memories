using System;
using UnityEngine;

public class TunnelMovement : MonoBehaviour
{
    private const float MoveSpeed = 20f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform helice;

    private void FixedUpdate()
    {
        var vel = rb.velocity;
        var h = Input.GetAxis("Horizontal") * MoveSpeed;
        var v = Input.GetAxis("Vertical") * MoveSpeed;
        rb.AddForce(new Vector3(h, v, 0), ForceMode.Impulse);
        helice.Rotate(Vector3.left, (float)Math.Sqrt(vel.x*vel.x + vel.y*vel.y)*0.2f + 4f, Space.Self);
        rb.velocity = Vector3.ClampMagnitude(vel, 10);
    }
}