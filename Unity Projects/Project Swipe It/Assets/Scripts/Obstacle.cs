using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public static Obstacle obstacleInstance;
    // Start is called before the first frame update
    void Awake()
    {
        obstacleInstance = this;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.z < -5)
            Destroy(gameObject);
    }
}
