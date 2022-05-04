using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameManager gameManager;
    private float spawnLimitX = 0;
    private float spawnLimitY = 30;
    private float spawnPosZ = 5;
    public int pointValue;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = RandomSpawnPos();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(spawnLimitX, spawnLimitY, Random.Range(-spawnPosZ, spawnPosZ));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Ground"))
        {
            gameManager.UpdateScore(pointValue);
            Destroy(gameObject);
        }
    }
}
