using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Courant : MonoBehaviour
{
    GameObject SubMarine;
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float backForce = 0f;
    public float rightForce = 500f;
    public float leftForce = 0f;
    public float upForce = 0f;
    public float downForce = 0f;




    private void OnTriggerStay(Collider collider)
        {
            if (collider.gameObject.name.Equals("Submarine"))
            {
                rb.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.VelocityChange);
                rb.AddForce(0, 0, - backForce * Time.deltaTime, ForceMode.VelocityChange);
                rb.AddForce(rightForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                rb.AddForce(-leftForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                rb.AddForce(0, upForce * Time.deltaTime, 0, ForceMode.VelocityChange);
                rb.AddForce(0, - downForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }
        }
}


