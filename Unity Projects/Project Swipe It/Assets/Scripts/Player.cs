using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    int score;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        string collidedObject = other.gameObject.tag;
        ColorChange(collidedObject);
    }
    void ColorChange(string collidedObject)
    {
        switch (collidedObject)
        {
            case "RedObstacle":
                {
                    score++;
                    Renderer[] playerColorChanger = gameObject.GetComponentsInChildren<Renderer>();
                    foreach (var a in playerColorChanger)
                    {
                        a.material.color = Color.red;
                    }
                    break;
                }
            case "GreenObstacle":
                {
                    score++;
                    Renderer[] playerColorChanger = gameObject.GetComponentsInChildren<Renderer>();
                    foreach (var a in playerColorChanger)
                    {
                        a.material.color = Color.green;
                    }
                    break;
                }
            case "BlueObstacle":
                {
                    score++;
                    Renderer[] playerColorChanger = gameObject.GetComponentsInChildren<Renderer>();
                    foreach (var a in playerColorChanger)
                    {
                        a.material.color = Color.blue;
                    }
                    break;
                }
            case "RedPath":
                {
                    score++;
                    Renderer[] playerColorChanger = gameObject.GetComponentsInChildren<Renderer>();
                    foreach (var a in playerColorChanger)
                    {
                        a.material.color = Color.red;
                    }
                    break;
                }
            case "GreenPath":
                {
                    score++;
                    Renderer[] playerColorChanger = gameObject.GetComponentsInChildren<Renderer>();
                    foreach (var a in playerColorChanger)
                    {
                        a.material.color = Color.green;
                    }
                    break;
                }
            case "BluePath":
                {
                    score++;
                    Renderer[] playerColorChanger = gameObject.GetComponentsInChildren<Renderer>();
                    foreach (var a in playerColorChanger)
                    {
                        a.material.color = Color.blue;
                    }
                    break;
                }
        }

    }
}

