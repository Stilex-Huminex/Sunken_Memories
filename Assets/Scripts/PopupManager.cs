using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private GameObject popup;
    [SerializeField] private Text text;
    private float popupTimer;

    private void Update()
    {
        if (popupTimer <= 0) return;
        popupTimer -= Time.deltaTime;
        if (popupTimer <= 0) popup.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (!collision.CompareTag("Popup")) return;
        popup.SetActive(true);
        popupTimer = 2;
        print(collision.name);
        switch (collision.name)
        {
            case "Cyber_Gem":
                text.text = "Une gemme cybernétique ! Elle me sera certainement utile.";
                break;
            case "Green_Gem":
                text.text = "Une gemme verte ! Elle me sera certainement utile.";
                break;
            case "Snow_Gem":
                text.text = "Une gemme de glace ! Elle me sera certainement utile.";
                break;
            case "Barrier":
                text.text = "Je devrais voir ce qui se trame ici avant de partir.";
                break;
            case "Submarine":
                text.text = "Appuyez sur E pour rentrer dans le sous-marin.";
                break;
            default:
                popup.SetActive(false);
                popupTimer = 0;
                break;
        }
    }
       
}
