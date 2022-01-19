using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPEEEEEN : MonoBehaviour
{
    [SerializeField] private MeshRenderer zob;
    [SerializeField] private MeshRenderer zob2;

    private void Awake()
    {
        if (PlayerPrefs.GetInt(gameObject.name) != 1) return;
        zob.enabled = true;
        zob2.enabled = true;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime*175, Space.World);
    }
}
