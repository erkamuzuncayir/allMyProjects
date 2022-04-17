using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public AudioSource sourceOne;
    public AudioSource sourceTwo;
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;
        
        Material material = Renderer.material;
        
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
        // This is calls ChangePosition() every 2 seconds
        InvokeRepeating("ChangePosition", 0, Random.Range(1,5));
        InvokeRepeating("ChangeScale", 0, Random.Range(1, 5));
        InvokeRepeating("ChangeMaterialColor", 0, Random.Range(1, 5));

    }

    void Update()
    {
        transform.Rotate(10.0f * (Time.deltaTime * Random.Range(1,10)), 0.0f, 0.0f);
    }
    
    void ChangePosition ()
    {
        transform.position = new Vector3(Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5));
        sourceOne.Play();
    }
    void ChangeScale() 
    {
        transform.localScale = Vector3.one * Random.Range(1, 5);
    }
    void ChangeMaterialColor()
    {
        Color newColor = new Color(Random.value, Random.value, Random.value);
        Renderer.material.color = newColor;
        sourceTwo.Play();

    }
}
