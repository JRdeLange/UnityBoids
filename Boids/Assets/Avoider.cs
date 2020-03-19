using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avoider : MonoBehaviour
{
    BoidSpawner boidSpawner;
    float avoidDistance = 5;
    GameObject[] boids;
    int ownID;
    List<GameObject> closeBoids = new List<GameObject>();
    Vector3 averageCloseBoidPosition;
    int nrOfCloseBoids;
    Mover mover;


    // Start is called before the first frame update
    void Start()
    {
        boidSpawner = GameObject.FindObjectOfType<BoidSpawner>();
        mover = GetComponent<Mover>();
    }

    // Update is called once per frame
    void Update()
    {
        ownID = GetComponent<BoidID>().getID();
        Avoid();
    }

    void Avoid(){
        
        if (findCloseBoids()){
            float averageBoidDistance = averageCloseBoidPosition.magnitude;
            if (averageBoidDistance > 0){
                // get the direction vector (klopt)
                float test = transform.root.transform.rotation.eulerAngles.z;
                Vector2 directionVector = Quaternion.Euler(0,0,test) * Vector2.up;

                // calculate average stuff (klopt)
                Vector2 averageCloseBoidPosition2D = new Vector2(averageCloseBoidPosition.x, averageCloseBoidPosition.y);
                float averageBoidAngle = Vector2.Angle(directionVector, averageCloseBoidPosition2D); //Vector3.Angle(transform.rotation.eulerAngles, averageCloseBoidPosition);

                // calculate repulsion stuff (klopt wss wel)
                float repulsion = averageBoidDistance / avoidDistance;
                float repulseAngle = 360 - ((averageBoidAngle + 180) % 360);

                // klopt wss niet
                print (directionVector + "  " + averageCloseBoidPosition2D + " angle: " + repulseAngle);
                Vector3 newRotation = transform.rotation.eulerAngles;
                newRotation.z = repulseAngle;
                transform.rotation = Quaternion.Euler(newRotation);
            }
        }
    }

    bool findCloseBoids(){
        closeBoids.Clear();
        averageCloseBoidPosition = Vector3.zero;
        nrOfCloseBoids = 0;
        foreach (GameObject boid in boidSpawner.getListOfBoids())
            if (boid.GetComponent<BoidID>().getID() != ownID){
                Vector3 distanceVector = boid.transform.position - transform.position;
                float distance = distanceVector.magnitude;
                if (distance < avoidDistance){
                    closeBoids.Add(boid);
                    nrOfCloseBoids++;
                    averageCloseBoidPosition += distanceVector;
                }
            }
        
        averageCloseBoidPosition /= nrOfCloseBoids;

        if (nrOfCloseBoids > 0) return true;
        return false;
    }
}
