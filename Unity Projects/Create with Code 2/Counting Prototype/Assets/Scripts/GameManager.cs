using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    public TextMeshProUGUI scoreText;
    private int score = 0;
    private float spawnRate = 2.0f;
    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;

        StartCoroutine(SpawnTarget());
        StartCoroutine(GameCountdown());
    }

    // Update is called once per frame

    public void UpdateScore()
    {

    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int ballIndex = Random.Range(0, ballPrefabs.Length);
            Instantiate(ballPrefabs[ballIndex]);
        }
    }
    IEnumerator GameCountdown()
    {
        yield return new WaitForSeconds(60);
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}