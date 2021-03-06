using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public AnimationCurve curve;
    public float duration = 1f;
    [SerializeField] private Player player;



    // Update is called once per frame
    public void Uwu()
    {
        StartCoroutine(Shaking());
    }
    IEnumerator Shaking()
    {
        player.enabled = false;
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;
        
        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }
        transform.position = startPosition;
        player.enabled = true;
    }
}
