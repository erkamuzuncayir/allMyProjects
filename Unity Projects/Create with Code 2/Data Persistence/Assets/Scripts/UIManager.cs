using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    //public InputField inputUserName;
    //public string menuUserName;
    // Start is called before the first frame update
    //public void Start()
    //{

    //}
    //public void GetUserName()
    //{
    //    menuUserName = inputUserName.text;
    //    DataPersistence.instance.UserName(menuUserName);
    //}
    public void LoadScene()
    {
        SceneManager.LoadScene("main");
    }
}
