using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public GameObject GameOverText;
    public Text HighestScoreText;

    private bool m_Started = false;
    public int m_Points;
    public string userName;

    private bool m_GameOver = false;

    // Start is called before the first frame update


    void Start()
    {
        UpdateHighestScore();
        userName = DataPersistence.instance.userName;
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
        UpdateHighestScore();
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }
    public void GameOver()
    {
        DataPersistence.instance.GetPoint(m_Points);
        DataPersistence.instance.SaveHighestScore();
        DataPersistence.instance.LoadHighestScore();
        UpdateHighestScore();
        m_GameOver = true;
        GameOverText.SetActive(true);
    }
    void UpdateHighestScore()
    {
        if(HighestScoreText != null)
        {
            if (DataPersistence.instance.highestScore > m_Points)
            {
                HighestScoreText.text = $"Best Score :  {DataPersistence.instance.highestUserName}  :   {DataPersistence.instance.highestScore}";
            }
            else
            {
                HighestScoreText.text = $"Best Score : {userName} : {m_Points} ";
            }
        }

    }

    //public void SetHighestScore(int newHighScore)
    //{
    //    highScore.text = $"Best Score : {userName} : {newHighScore}";
    //    instance.highestScore = newHighScore;
    //}
    ////void UserName(string userName)
    ////{
    ////    userName = inputUserName.ToString();
    ////}

}
