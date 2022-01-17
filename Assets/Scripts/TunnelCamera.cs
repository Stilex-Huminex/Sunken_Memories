using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelCamera : MonoBehaviour
{
    [SerializeField] private Transform sub;

    // Update is called once per frame
    private void Update()
    {
        transform.LookAt(sub);
    }
}
