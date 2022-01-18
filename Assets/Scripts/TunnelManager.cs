using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TunnelManager : MonoBehaviour
{
    [SerializeField] private Text speed;
    [SerializeField] private Slider progress;
    private float distance;

    private void Awake()
    {
        distance = 0;
    }

    public void Update()
    {
        distance += TunnelMovement.TravelSpeed;
        if (distance > 1000) SceneManager.LoadScene("TerrainTest");
        var nb = (int)(TunnelMovement.TravelSpeed * 200);
        speed.text = nb + " km/h";
        progress.value = distance / 1000;
    }
}
