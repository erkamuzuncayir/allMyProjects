using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class DataPersistence : MonoBehaviour
{
    public static DataPersistence instance;
    public int playerScore;
    public int highestScore;
    public string highestUserName;
    public string userName;
    public InputField inputUserName;
    public int userScore;
    // Start is called before the first frame update
    private void Start()
    {

    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighestScore();
    }
    public void GetUserName()
    {
        userName = inputUserName.text;
    }
    public void GetPoint(int userPoint)
    {
        userScore = userPoint;
    }
    [System.Serializable]
    public class SaveData
    {
        public static SaveData instance;
        public int highestScore = 0;
        public string highestUserName;
    }
    public void SaveHighestScore()
    {
        if (highestScore < userScore)
        {
            SaveData data = new SaveData();
            data.highestScore = userScore; 
            data.highestUserName = userName;
            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefileee.json", json);
        }
    }
    public void LoadHighestScore()
    {
        string path = Application.persistentDataPath + "/savefileee.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highestUserName = data.highestUserName;
            highestScore = data.highestScore;
        }
        //if(MainManager.instance != null)
        //{
        //    MainManager.instance.UpdateHighestScore();
        //}

    }
    //public void UpdateHighestScore()
    //{
    //    if(highestScore > userScore)
    //    {
    //        MainManager.instance.HighestScoreText.text = "Best Score : " + highestUserName + " : " + highestScore.ToString();
    //    }
    //    else
    //    {
    //        MainManager.instance.HighestScoreText.text = "Best Score : " + userName + " : " + MainManager.instance.m_Points.ToString();
    //    }
    //}

}