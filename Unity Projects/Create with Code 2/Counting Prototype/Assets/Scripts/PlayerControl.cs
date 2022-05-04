using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Camera mainCamera;
    private float cameraZDistance;
    void Start()
    {
        mainCamera = Camera.main;
        cameraZDistance = mainCamera.WorldToScreenPoint(transform.position).z;
    }
    
    void OnMouseDrag()
    {
        Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraZDistance);
        Vector3 newWorldPosition = mainCamera.ScreenToWorldPoint(screenPosition);
        transform.position = newWorldPosition;
    }

}
