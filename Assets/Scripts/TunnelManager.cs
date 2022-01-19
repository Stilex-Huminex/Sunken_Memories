using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TunnelManager : MonoBehaviour
{
    [SerializeField] private Text speed;
    [SerializeField] private Slider progress;
    [SerializeField] private string nextScene;
    private float _distance;

    private void Awake()
    {
        _distance = 0;
    }

    public void Update()
    {
        _distance += TunnelMovement.TravelSpeed;
        if (_distance > 3500 || Input.GetKeyDown(KeyCode.PageUp)) SceneManager.LoadScene(nextScene);
        var nb = (int)(TunnelMovement.TravelSpeed * 200);
        speed.text = nb + " km/h";
        progress.value = _distance / 3500;
    }
}
