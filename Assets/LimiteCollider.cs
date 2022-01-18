using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteCollider : MonoBehaviour
{
    public Rigidbody rb;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name.Equals("Player"))
        {
            rb.transform.position = new Vector3(80f, 600f, 90f);
        }
        
    }
}
