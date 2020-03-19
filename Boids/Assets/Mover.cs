using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    public float speed;
    Camera cam;
    float halfCameraX;
    float halfCameraY;
    float halfWidth;
    float halfHeigt;
    Vector2 movement;



    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        halfWidth = transform.localScale.x / 2;
        halfHeigt = transform.localScale.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        movement = Vector2.up * speed * Time.deltaTime;
        transform.Translate(movement);
        halfCameraY = cam.orthographicSize;
        halfCameraX = halfCameraY * cam.aspect;
        wrapAround();
    }

    void wrapAround(){
        float xEdgeValue = halfCameraX + halfWidth;
        float yEdgeValue = halfCameraY + halfHeigt;
        Vector3 newPos = transform.position;
        if(transform.position.x > xEdgeValue) newPos.x = -xEdgeValue;
        if(transform.position.x < -xEdgeValue) newPos.x = xEdgeValue;
        if(transform.position.y > yEdgeValue) newPos.y = -yEdgeValue;
        if(transform.position.y < -yEdgeValue) newPos.y = yEdgeValue;
        transform.position = newPos;
    }

    public Vector2 GetMovementVector(){
        return movement;
    }
}
