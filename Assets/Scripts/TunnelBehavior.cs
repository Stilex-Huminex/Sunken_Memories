using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelBehavior : MonoBehaviour
{
    [SerializeField] private Transform other;
    private float _startZ;
    private float _diff;

    private void Start()
    {
        _startZ = transform.position.z;
        _diff = other.position.z - _startZ;
    }

    private void Update()
    {
        transform.Translate(Vector3.back*TunnelMovement.TravelSpeed);
        other.Translate(Vector3.back*TunnelMovement.TravelSpeed);
        if (!(other.position.z < _startZ)) return;
        transform.Translate(Vector3.forward*_diff);
        other.Translate(Vector3.forward*_diff);
    }
}
