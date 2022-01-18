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

    private void OnCollisionEnter(Collision collision)
    {
        popup.SetActive(true);
        popupTimer = 2;
        switch (collision.collider.name)
        {
            case "Gem":
                text.text = "Appuyez sur 'E' pour ramasser.";
                break;
            case "Barrier":
                text.text = "Je devrais voir ce qui se trame ici avant de partir.";
                break;
            default:
                popup.SetActive(false);
                popupTimer = 0;
                break;
        }
    }
}
