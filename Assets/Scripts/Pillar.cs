using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    private enum Gems
    {
        Cyber_Gem,
        Snow_Gem,
        Green_Gem
    }
    
    public GameObject gem;

    [SerializeField] private Gems gemme;
    
    private bool _canPut;

    public void Update()
    {
        var myGem = gemme.ToString();
        if (!Input.GetKeyDown(KeyCode.E) || !_canPut || PlayerPrefs.GetInt(myGem) != 1) return;
        PlayerPrefs.SetInt(myGem, 0);
        PlayerPrefs.SetInt(myGem + "_done", 1);
        gem.SetActive(true);
    }
    private void OnTriggerStay(Collider colliderInfo)
    {
        if (!colliderInfo.gameObject.name.Equals("Player")) return;
        _canPut = true;
    }
    private void OnTriggerExit(Collider colliderInfo)
    {
        if (!colliderInfo.gameObject.name.Equals("Player")) return;
        _canPut = false;
    }
}
