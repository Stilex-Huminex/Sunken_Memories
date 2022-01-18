using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;

public class SpawnSeaLife : MonoBehaviour
{
    [SerializeField] private new BoxCollider collider;
    [SerializeField] private int nbSpawns;
    [SerializeField] private GameObject medusa;
    [SerializeField] private GameObject squid;
    // Start is called before the first frame update
    private void Start()
    {
        for (var i = 0; i < nbSpawns; i++)
        {
            var toClone = Random.Range(1, 10) < 8 ? medusa : squid;
            Instantiate(toClone, RandomPointInBounds(collider.bounds), Quaternion.identity);
        }
    }
    
    private Vector3 RandomPointInBounds(Bounds bounds) {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
}
