using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField] private Scene toLoad;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name.Equals("Player"))
        {
            SceneManager.LoadScene(toLoad.buildIndex);
        }
    }
}