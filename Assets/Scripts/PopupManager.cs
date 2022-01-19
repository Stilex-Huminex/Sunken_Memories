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
            case "Debut":
                text.text = "Je suis bloqué ici ... Il faut que je trouve un moyen de rentrer chez moi.";
                collision.enabled = false;
                popupTimer = 7;
                break;
            case "Plage":
                text.text = "Mon sous marin a fini dans l'eau ! Je vais vérifier s'il est toujours en état de marche.";
                collision.enabled = false;
                popupTimer = 7;
                break;
            default:
                popup.SetActive(false);
                popupTimer = 0;
                break;
        }
    }
       
}
