using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillier2 : MonoBehaviour
{
    public GameObject instructions;
    public GameObject item2;
    private bool poser = false;
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.name.Equals("Player") & FindObjectOfType<Event>().Recuperer2() & poser==false)
        {
            instructions.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                FindObjectOfType<Event>().Drop(2);

                item2.SetActive(true);
                item2.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 3, gameObject.transform.position.z);
                instructions.SetActive(false);
                poser = true;


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
