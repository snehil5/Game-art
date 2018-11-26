using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerShake : MonoBehaviour {
    Vector3 cameraInitial;
    public float magnitude = 0.05f, shaketime = 0.5f;
    public Camera mainCamera;

	

    public void Shake()
    {
        
        cameraInitial = mainCamera.transform.position;
        InvokeRepeating("StartCameraShaking", 0f, 0.005f);
        Invoke("StopCameraShaking", shaketime);
    }

    void StartCameraShaking()
    {
        
        float cameraShakingOffsetX = Random.value * magnitude * 2 - magnitude;
        float cameraShakingOffsetY = Random.value * magnitude * 2 - magnitude;
        Vector3 cameraIntermediatePosition = mainCamera.transform.position;
        cameraIntermediatePosition.x += cameraShakingOffsetX;
        cameraIntermediatePosition.y += cameraShakingOffsetY;
        mainCamera.transform.position = cameraIntermediatePosition;


    }

    void StopCameraShaking()
    {
        CancelInvoke("StartCameraShaking");
        mainCamera.transform.position = cameraInitial;
    }
}
