using System;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.back*TunnelMovement.TravelSpeed*Time.deltaTime*450f, Space.World);
        if (transform.position.z < -25f)
        {
            Destroy(gameObject);
        }
    }
}
