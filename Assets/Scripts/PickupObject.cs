using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class PickupObject : MonoBehaviour
{
    [SerializeField] private GameObject barrier;
    [SerializeField] private bool final;
    private bool _canPickup;
    private float _startY;

    
    private void Start()
    {
        _startY = transform.position.y;
        if (final && PlayerPrefs.GetInt(gameObject.name + "_done") != 1)
        {
            gameObject.SetActive(false);
            return;
        }
        if (PlayerPrefs.GetInt(gameObject.name) != 1) return;
        gameObject.SetActive(false);
        barrier.SetActive(false);
    }

    public void Update()
    {
        print(_startY);
        var pos = transform.position;
        transform.Rotate(Vector3.up, 30f*Time.deltaTime, Space.World);
        transform.position = new Vector3(pos.x, _startY + (float) Math.Sin(Time.time*2f)/5f, pos.z);
        if (final) return;
        if (!Input.GetKeyDown(KeyCode.E) || !_canPickup) return;
        PlayerPrefs.SetInt(gameObject.name, 1);
        barrier.SetActive(false);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider collisionInfo)
    {
        if (final) return;
        if (!collisionInfo.gameObject.name.Equals("Player")) return;
        _canPickup = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (final) return;
        if (!other.gameObject.name.Equals("Player")) return;
        _canPickup = false;
    }

}