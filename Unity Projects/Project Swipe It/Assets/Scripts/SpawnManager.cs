using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager spawnManagerInstance;
    public GameObject[] obstaclePrefabs, destroyableObjects;
    public GameObject obstacleClone;
    public int willBeSpawnObject;
    private Vector3 spawnPos = new Vector3(0, 2, 0);
    private float startDelay = 2;
    private float repeatRate = 5;
    // Start is called before the first frame update
    void Awake()
    {
        spawnManagerInstance = this;
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        //foreach (GameObject road in roadPieces)
        //{
        //    Vector3 newRoadPos = road.transform.position;
        //    newRoadPos.z -= roadSpeed * Time.deltaTime;
        //    if (newRoadPos.z < -roadLength / 2)
        //    {
        //        newRoadPos.z += roadLength;
        //    }
        //    road.transform.position = newRoadPos;
        //}        
    }
    void SpawnObstacle()
    {
        if(obstacleClone)
        {

            spawnPos.z = Random.Range(10, 50) + (obstacleClone.transform.position.z + 10);
        }
        else
        {
            spawnPos.z = Random.Range(15, 50);
        }
        willBeSpawnObject = Random.Range(0,3);
        if (!Player.playerInstance.isPlayerDead)
        {
            obstacleClone = Instantiate(obstaclePrefabs[willBeSpawnObject], spawnPos, obstaclePrefabs[willBeSpawnObject].transform.rotation);
        }
    }
}
