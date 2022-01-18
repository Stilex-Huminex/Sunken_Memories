using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField] private string toLoad;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name.Equals("Player") || collision.collider.name.Equals("Submarine"))
        {
            SceneManager.LoadScene(toLoad);
        }
    }
}