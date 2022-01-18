using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickupObject : MonoBehaviour
{
    public GameObject instructions;
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.name.Equals("Player"))
        {
            instructions.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                FindObjectOfType<Event>().PickUp(Int32.Parse(gameObject.name));
                gameObject.SetActive(false);
                instructions.SetActive(false);
                

            }
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name.Equals("Player"))
        {
            instructions.SetActive(false);
        }
    }
}
