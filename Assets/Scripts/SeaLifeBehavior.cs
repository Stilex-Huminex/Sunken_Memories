using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class SeaLifeBehavior : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private List<Renderer> meshs;
    [SerializeField] private Shader shader;
    [SerializeField] private Animator anim;
    private float _moveCd = 1.75f;
    private bool move;
    private float totalRota;

    private Vector3 _targetRota;
    // Start is called before the first frame update
    private void Start()
    {
        var x = Random.Range(0, 360);
        var y = Random.Range(0, 360);
        var z = Random.Range(0, 360);
        transform.rotation = Quaternion.Euler(x,y,z);
        _targetRota = transform.forward;
        if (!gameObject.name.StartsWith("Meduse")) return;
        var color = Random.ColorHSV(0, 1, 1, 1, 1, 1) * 6;
        foreach (var mesh in meshs)
        {
            var mat = new Material(shader);
            mat.SetColor("Color_efae2c7a000a4cf78318a8e0b336fdac", color);
            mesh.sharedMaterial = mat;
        }
    }

    private void Update()
    {
        if (move && totalRota < 180f) transform.Rotate(0, Time.deltaTime * 100, 0, Space.Self);
        _moveCd += Time.deltaTime;
        if (!(_moveCd >= 2.1f)) return;
        anim.Play("Scene");
        _moveCd -= 2.1f;
        rb.AddForce(transform.forward*-10f, ForceMode.Impulse);
    }


    private void OnTriggerExit(Collider other)
    {
        if (!other.name.Equals("Spawner")) return;
        move = true;
        _targetRota = transform.eulerAngles + 180f * transform.up;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.name.Equals("Spawner")) return;
        move = false;
    }
}
