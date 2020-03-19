using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamInfo : MonoBehaviour
{

    public float halfCameraX;
    public float halfCameraY;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        halfCameraY = cam.orthographicSize;
        halfCameraX = halfCameraY * cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        halfCameraY = cam.orthographicSize;
        halfCameraX = halfCameraY * cam.aspect;
    }

    public float getHalfX(){
        return halfCameraX;
    }

    public float getHalfY(){
        return halfCameraY;
    }

}
