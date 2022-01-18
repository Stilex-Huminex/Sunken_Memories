using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    enum gems
    {
        Red_Gem,
        Green_Gem,
        Blue_Gem
    }
    
    public GameObject gem;

    [SerializeField] private gems gemme;
    
    private bool _canPut;

    public void Update()
    {
        var myGem = gemme.ToString();
        if (!Input.GetKeyDown(KeyCode.E) || !_canPut || PlayerPrefs.GetInt(myGem) != 1) return;
        PlayerPrefs.SetInt(myGem, 0);
        PlayerPrefs.SetInt(myGem + "_done", 1);
        gem.SetActive(true);
    }
    private void OnTriggerStay(Collider collider)
    {
        if (!collider.gameObject.name.Equals("Player")) return;
        _canPut = true;
    }
    private void OnTriggerExit(Collider collider)
    {
        if (!collider.gameObject.name.Equals("Player")) return;
        _canPut = false;
    }
}
