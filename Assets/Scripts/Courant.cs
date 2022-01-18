using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Courant : MonoBehaviour
{
    GameObject SubMarine;
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;


    
    private void OnTriggerStay(Collider collider)
        {
            if (collider.gameObject.name.Equals("Submarine"))
            {
                rb.AddForce(0, 0, forwardForce * Time.deltaTime);
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
             }
        }
}


