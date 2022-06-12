using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;
    public GameObject newGameButton;
    public GameObject loadGameButton;
    public GameObject scoretableButton;
    public GameObject deathScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.playerInstance.isPlayerDead)
        {
            deathScreen.SetActive(true);
        }
        else
        {
            deathScreen.SetActive(false);
        }
    }
    public void StartNewGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
