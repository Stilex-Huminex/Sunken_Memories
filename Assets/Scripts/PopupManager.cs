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
                popupTimer = 6;
                break;
            case "Courant":
                text.text = "Les courants marins ont l'air d'amener quelque part.";
                collision.enabled = false;
                popupTimer = 6;
                break;
            case "Tunnel":
                text.text = "Cela m'a amené a un passage ! C'est surement un tunnel pour ma liberté !";
                collision.enabled = false;
                popupTimer = 6;
                break;
            case "Cyber_Gem_Pillar":
                text.text = "On dirait que je peux placer une gemme rouge ici.";
                break;
            case "Snow_Gem_Pillar":
                text.text = "On dirait que je peux placer une gemme bleue ici.";
                break;
            case "Green_Gem_Pillar":
                text.text = "On dirait que je peux placer une gemme verte ici.";
                break;
            case "Portail":
                text.text = "Il semblerait que quelque chose aie bougé un peu plus loin.";
                popupTimer = 6;
                break;
            default:
                popup.SetActive(false);
                popupTimer = 0;
                break;
        }
    }
       
}
