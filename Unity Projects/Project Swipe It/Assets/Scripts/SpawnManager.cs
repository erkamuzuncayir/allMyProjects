using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private float[] spawnPosX = new float[] { -2f, 0f, 2f };
    private Vector3 spawnPos = new Vector3(0,2,0);
    private float startDelay = 2;
    private float repeatRate = 2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnObstacle()
    {
        spawnPos.x = spawnPosX[Random.Range(0, 3)];
        spawnPos.z = Random.Range(5, 50);
        int willBeSpawnObj = Random.Range(0, 3);
        Instantiate(obstaclePrefabs[willBeSpawnObj], spawnPos, obstaclePrefabs[willBeSpawnObj].transform.rotation);
    }
}
