using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    private bool open = false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            if (open == false & FindObjectOfType<Event>().Ouvert())
            {
                open = true;
                Animator anim = door.GetComponentInChildren<Animator>();
                anim.SetTrigger("Open");
                FindObjectOfType<Shake>().Uwu();
            }
            
        }
    }
}
