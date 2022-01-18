using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickupObject : MonoBehaviour
{
    public GameObject instructions;
    public bool OK = false;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) & OK )
        {
            FindObjectOfType<Event>().PickUp(Int32.Parse(gameObject.name));
            
            gameObject.SetActive(false);
            instructions.SetActive(false);


        }
    }
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.name.Equals("Player"))
        {
            instructions.SetActive(true);
            OK = true;
            
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name.Equals("Player"))
        {
            instructions.SetActive(false);
            OK = false;
        }
    }
}
