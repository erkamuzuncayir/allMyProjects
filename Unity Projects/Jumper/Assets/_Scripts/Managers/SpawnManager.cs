using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] environmentPrefabs;
    public GameObject environmentClone;
    private List<GameObject> _spawnedEnvironments = new List<GameObject>();
    private Vector3 _environmentSpawnPos = new Vector3(0, -101, 99);
    private const float RepeatRate = 3, StartDelay = 0f;
    public float gameSpeed = 30;
    public float difficultyMultiplier = 1;
    private bool _isPlayerDead;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnvironments), StartDelay, RepeatRate);
    }

    // Update is called once per frame
    public void Update()
    {
        var isGrounded = PlayerController.Instance.isGrounded;
        foreach (var e in _spawnedEnvironments)
        {
            /*if (isGrounded)
            {
                e.transform.Translate(Vector3.back * (Time.deltaTime * gameSpeed));
            }
            else
            {
                e.transform.Translate(Vector3.back * (Time.deltaTime * gameSpeed));
            }*/

            if (e.transform.position.z < -101)
            {
                Destroy(e);
                _spawnedEnvironments.Remove(e);
            }
        }
    }

    private void SpawnEnvironments()
    {
        var environmentRandX = Random.Range(0, 2);
        var environmentRandY = Random.Range(-101, -75);
        if (environmentRandX == 1)
        {
            _environmentSpawnPos.x = 0;
        }
        else
        {
            _environmentSpawnPos.x = 0;
        }

        if (environmentClone != null)
        {
            _environmentSpawnPos.y = environmentRandY;
            _environmentSpawnPos.z = (environmentClone.transform.position.z + Random.Range(230, 300));
        }
        /*else
        {
            
            _environmentSpawnPos.z = Random.Range(0, 50);
        }*/

        var willBeSpawnEnvironment = Random.Range(0, 1);
        if (_isPlayerDead) return;
        environmentClone = Instantiate(environmentPrefabs[willBeSpawnEnvironment], _environmentSpawnPos,
            environmentPrefabs[willBeSpawnEnvironment].transform.rotation);
        var spawnedEnvironment = environmentClone;
        _spawnedEnvironments.Add(spawnedEnvironment);
    }
}