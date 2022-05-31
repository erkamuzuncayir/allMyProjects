using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    bool isCollected;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool GetIsCollected()
    {
        return isCollected;
    }
    public void BeCollected()
    {
        isCollected = true;
    }
    public void SetIndex(int index)
    {
        this.index = index;
    }
}
