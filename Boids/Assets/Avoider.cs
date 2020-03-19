using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avoider : MonoBehaviour
{
    BoidSpawner boidSpawner;
    public float avoidDistance;
    GameObject[] boids;
    int ownID;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ownID = GetComponentInParent<BoidID>().getID();
        GetBoidsList();
        Avoid();
    }

    void Avoid(){
        GameObject[] closeBoids;
        int nrOfCloseBoids;
        foreach (GameObject boid in boids)
        {
            float distance = (transform.position - boid.transform.position).magnitude;
            if (distance < avoidDistance){
                
            }
            print(distance);
        }
    }

    void GetBoidsList(){
        print ("CHANGED");
        boids = GameObject.FindGameObjectsWithTag("Boid");
        Mover mover = boids[0].GetComponentInChildren<Mover>();
    }
}
