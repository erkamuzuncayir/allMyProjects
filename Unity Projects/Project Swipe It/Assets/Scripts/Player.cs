using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum ROAD { RED, GREEN, BLUE }
public class Player : MonoBehaviour
{
    public static Player playerInstance;
    public GameObject[] roads = new GameObject[3];
    [SerializeField] private Renderer redRoadTransparent, greenRoadTransparent, blueRoadTransparent;
    private Renderer[] playerColorChanger;
    [SerializeField] private Color redRoadColor, greenRoadColor, blueRoadColor;
    private string whichRoad, collidedObject, collidedObjectColor;
    private byte red, green, blue = 0;
    public bool isPlayerDead = false;
    private float playerXPos;
    private ROAD playerRoad;
    [SerializeField] private string canPassObstacle;
    [SerializeField] private float increasingValue, decreasingValue, nonChangingColor, alphaIncrease, alphaDecrease, alphaValue;
    float maxMyValue = 255;
    float minMyValue;
    float myValue = 10;
    float changePerSecond;
    float timeToChange = 10;

    // Start is called before the first frame update
    void Start()
    {
        playerInstance = this;
        playerColorChanger = gameObject.GetComponentsInChildren<Renderer>();
        redRoadTransparent = roads[0].GetComponent<Renderer>();
        greenRoadTransparent = roads[1].GetComponent<Renderer>();
        blueRoadTransparent = roads[2].GetComponent<Renderer>();
        redRoadColor = redRoadTransparent.sharedMaterial.color;
        greenRoadColor = greenRoadTransparent.sharedMaterial.color;
        blueRoadColor = blueRoadTransparent.sharedMaterial.color;
    }
    private void OnTriggerEnter(Collider other)
    {
        collidedObject = other.gameObject.tag;
        collidedObjectColor = other.gameObject.name;
        if (collidedObject == "RedTrigger" || collidedObject == "GreenTrigger" || collidedObject == "BlueTrigger")
        {
            increasingValue = 0;
        }
        if (collidedObject == "Obstacle" && canPassObstacle != collidedObjectColor)
        {
            isPlayerDead = true;
            PlayerController.playerControllerInstance.DeathMove(isPlayerDead);
        }
    }
    // Update is called once per frame
    void Update()
    {
        playerXPos = this.transform.position.x;



        ColorChanger();
    }
    void ColorChanger()
    {

        // YAZACA?IMIZ METHOD ?LE RENKLER HANG? DE?ERDE KALDIYSA ORADAN ALIP 255'E TAMAMLAYACAK.
        //case "RedObstacle":
        //    {
        //        score++;
        //        foreach (var a in playerColorChanger)
        //        {
        //            a.material.color = new Color32(red, green, blue, 255);
        //        }
        //        break;
        //    }
        //case "GreenObstacle":
        //    {
        //        score++;
        //        foreach (var a in playerColorChanger)
        //        {
        //            a.material.color = Color.green;
        //        }
        //        break;
        //    }
        //case "BlueObstacle":
        //    {
        //        score++;
        //        foreach (var a in playerColorChanger)
        //        {
        //            a.material.color = Color.blue;
        //        }
        //        break;
        //    }
        if (collidedObject == "RedTrigger" && playerXPos > 1 )
        {
            ValueChanger(redRoadTransparent.sharedMaterial.color.r * 255);
            red = (byte)increasingValue;
            green = (byte)decreasingValue;
            blue = (byte)decreasingValue;
            foreach (var a in playerColorChanger)
            {
                a.material.color = new Color32(red, green, blue, 255);
            }
            redRoadTransparent.sharedMaterial.color = new Color32(255, 0, 0, (byte)decreasingValue);
            if (greenRoadTransparent.sharedMaterial.color.a < 0.8f)
            {
                ColorFiller(greenRoadTransparent.sharedMaterial.color.a * 255);
                greenRoadTransparent.sharedMaterial.color = new Color32(0, 255, 0, (byte)alphaIncrease);
            }
            if (blueRoadTransparent.sharedMaterial.color.a < 0.8f)
            {
                ColorFiller(blueRoadTransparent.sharedMaterial.color.a * 255);
                blueRoadTransparent.sharedMaterial.color = new Color32(0, 0, 255, (byte)(alphaIncrease));
            }
            if (red > 240)
            {
                canPassObstacle = "RedObstacle(Clone)";
            }
            else
            {
                canPassObstacle = "cannot";
            }
        }
        else if (collidedObject == "GreenTrigger" && playerXPos < 1 && playerXPos > -1)
        {
            ValueChanger(greenRoadTransparent.sharedMaterial.color.g * 255);
            red = (byte)decreasingValue;
            green = (byte)increasingValue;
            blue = (byte)decreasingValue;
            foreach (var a in playerColorChanger)
            {
                a.material.color = new Color32(red, green, blue, 255);
            }
            greenRoadTransparent.sharedMaterial.color = new Color32(0, 255, 0, (byte)decreasingValue);
            if (redRoadTransparent.sharedMaterial.color.a < 0.8f)
            {
                ColorFiller(redRoadTransparent.sharedMaterial.color.a * 255);
                redRoadTransparent.sharedMaterial.color = new Color32(255, 0, 0, (byte)alphaIncrease);
            }
            if(blueRoadTransparent.sharedMaterial.color.a < 0.8f)
            {
                ColorFiller(blueRoadTransparent.sharedMaterial.color.a * 255);
                blueRoadTransparent.sharedMaterial.color = new Color32(0, 0, 255, (byte)alphaIncrease);
            }
            if (green > 240)
            {
                canPassObstacle = "GreenObstacle(Clone)";
            }
            else
            {
                canPassObstacle = "cannot";
            }
        }
        else if (collidedObject == "BlueTrigger" && playerXPos < -1)
        {
            ValueChanger(blueRoadTransparent.sharedMaterial.color.b * 255);
            red = (byte)decreasingValue;
            green = (byte)decreasingValue;
            blue = (byte)increasingValue;
            foreach (var a in playerColorChanger)
            {
                a.material.color = new Color32(red, green, blue, 255);
            }
            blueRoadTransparent.sharedMaterial.color = new Color32(0, 0, 255, (byte)decreasingValue);
            if (redRoadTransparent.sharedMaterial.color.a < 0.8f)
            {
                ColorFiller(redRoadTransparent.sharedMaterial.color.a*255);
                redRoadTransparent.sharedMaterial.color = new Color32(255, 0, 0, (byte)alphaIncrease);
            }
            if(greenRoadTransparent.sharedMaterial.color.a < 0.8f)
            {
                ColorFiller(greenRoadTransparent.sharedMaterial.color.a * 255);
                greenRoadTransparent.sharedMaterial.color = new Color32(0, 255, 0, (byte)alphaIncrease);

            }
            if (blue > 240)
            {
                canPassObstacle = "BlueObstacle(Clone)";
            }
            else
            {
                canPassObstacle = "cannot";
            }
        }
    }
    void ValueChanger(float currentValue)
    {
        currentValue = 255 - currentValue;
        if (increasingValue < 255)
        {
            increasingValue += Mathf.MoveTowards(currentValue, 255, 0.5f);
        }
        if(decreasingValue > -1)
        {
            decreasingValue = 255 - increasingValue;
        }
    }
    // PARAMETRE S?L?NECEK. BU ?EK?LDE ÇALI?IYOR. BUG TEST? YAP Y?NE DE
    void ColorFiller(float currentValue)
    {
        Debug.Log(redRoadTransparent.sharedMaterial.color.a);
        if(alphaIncrease < 254)
        alphaIncrease+= Mathf.MoveTowards(0, 255, 0.5f);
    }
}


