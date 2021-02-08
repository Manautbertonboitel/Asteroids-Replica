using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LoopPosition : MonoBehaviour
{
    public float boundaries;
    private Camera mainCamera;
    public float cameraWidth;
    public float cameraHeight;

    private void Start()
    {
        mainCamera = Camera.main;
        cameraHeight = mainCamera.orthographicSize;
        cameraWidth = cameraHeight * mainCamera.aspect;
    }
    void Update()
    {
        
        //Camera.main.orthographicSize;

        float objectPosX = transform.position.x;
        float playerPosY = transform.position.y;    

        if (objectPosX < -cameraWidth - boundaries)
        {
            transform.position = new Vector3(cameraWidth + boundaries, playerPosY, 0);
        } else if (objectPosX > cameraWidth + boundaries) 
        {
            transform.position = new Vector3(-cameraWidth - boundaries, playerPosY, 0);
        }

        if (playerPosY < -cameraHeight - boundaries)
        {
            transform.position = new Vector3(objectPosX, cameraHeight + boundaries, 0);
        } else if (playerPosY > cameraHeight + boundaries)
        {
            transform.position = new Vector3(objectPosX, -cameraHeight - boundaries, 0);
        }
    }
}
