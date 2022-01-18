using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private GameObject circle;
    [SerializeField] private List<Transform> spawnPoints;
    private float timeToSpawn;

    private void Update()
    {
        timeToSpawn += Time.deltaTime;
        if (!(timeToSpawn >= 0.2f/TunnelMovement.TravelSpeed)) return;
        timeToSpawn -= 0.2f/TunnelMovement.TravelSpeed;
        var spawn = Random.Range(0, spawnPoints.Count);
        if (spawn < spawnPoints.Count - 1)
        {
            var x = Random.Range(-30, 30);
            var y = Random.Range(-30, 30);
            var z = Random.Range(-30, 30);
            var clone = Instantiate(obstacle, spawnPoints[spawn].position, spawnPoints[spawn].localRotation);
            clone.transform.Rotate(x,y,z);
        }
        else
        {
            var z = Random.Range(0, 360);
            var clone = Instantiate(circle, spawnPoints[spawn].position, Quaternion.identity);
            clone.transform.Rotate(0,0,z);
        }
    }
}
