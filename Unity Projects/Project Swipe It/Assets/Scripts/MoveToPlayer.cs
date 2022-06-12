using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    private float gameSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Player.playerInstance.isPlayerDead)
        {
            transform.Translate(Vector3.back * Time.deltaTime * gameSpeed);
        }
    }
}
