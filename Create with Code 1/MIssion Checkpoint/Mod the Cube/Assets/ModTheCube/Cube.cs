using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.5f;
    }
    
    void Update()
    {
        Material material = Renderer.material;
        material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.5f, 1.0f), Random.Range(0.0f, 1.0f), 0.4f);
        transform.Rotate(30.0f * Time.deltaTime, 0.0f, 25.0f * Time.deltaTime);
    }
}
