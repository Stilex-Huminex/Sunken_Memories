using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterView : MonoBehaviour
{
    [SerializeField] private Color fogEarth;
    [SerializeField] private Color fogWater;

    [SerializeField] private GameObject postEarth;
    [SerializeField] private GameObject postWater;

    [SerializeField] private GameObject upWater;
    [SerializeField] private GameObject downWater;

    [SerializeField] private GameObject cameraPlayer;
    [SerializeField] private GameObject cameraSubmarine;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fogColor = fogEarth;
        postWater.SetActive(false);
        downWater.SetActive(false);

        upWater.SetActive(true);
        postEarth.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraPlayer.transform.position.y < 576 || cameraSubmarine.transform.position.y < 576)
        {
            downWater.SetActive(true);
            postWater.SetActive(true);

            upWater.SetActive(false);
            postEarth.SetActive(false);


            RenderSettings.fogColor = fogWater;
            RenderSettings.fogDensity = 0.001f;
        }
        else
        {
           
            postWater.SetActive(false);
            downWater.SetActive(false);

            upWater.SetActive(true);
            postEarth.SetActive(true);

            RenderSettings.fogColor = fogEarth;
            RenderSettings.fogDensity = 0.001f;
        }
    }
}
