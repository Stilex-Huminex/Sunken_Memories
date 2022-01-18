using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBird : MonoBehaviour
{
    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim.Play("Scene");
        anim.Play("WaterBirdMoving");
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
