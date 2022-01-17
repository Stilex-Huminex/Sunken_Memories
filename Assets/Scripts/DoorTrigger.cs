using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject door;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            Animator anim = door.GetComponentInChildren<Animator>();
            anim.SetTrigger("Open");
            FindObjectOfType<Shake>().Start();
            
        }
    }
}
