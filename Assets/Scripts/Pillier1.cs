using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillier1 : MonoBehaviour
{
    public GameObject instructions;
    public GameObject item1;

    private bool poser = false;
    private bool OK = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && OK)
        {
            FindObjectOfType<Event>().Drop(1);

            item1.SetActive(true);
            item1.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 3, gameObject.transform.position.z);
            instructions.SetActive(false);
            poser = true;


        }
    }
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.name.Equals("Player") && FindObjectOfType<Event>().Recuperer1() && !poser)
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
