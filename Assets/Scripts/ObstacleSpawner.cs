using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private List<Transform> spawnPoints;
    private float timeToSpawn;

    private void Update()
    {
        timeToSpawn += Time.deltaTime;
        if (!(timeToSpawn >= 0.2f/TunnelMovement.TravelSpeed)) return;
        timeToSpawn -= 0.2f/TunnelMovement.TravelSpeed;
        var spawn = Random.Range(0, spawnPoints.Count);
        var x = Random.Range(-30, 30);
        var y = Random.Range(-30, 30);
        var z = Random.Range(-30, 30);
        var clone = Instantiate(obstacle, spawnPoints[spawn].position, spawnPoints[spawn].localRotation);
        clone.transform.Rotate(x,y,z);
    }
}
