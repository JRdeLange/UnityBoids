using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BoidSpawner : MonoBehaviour
{

    public GameObject boid;
    public CamInfo camInfo;
    public int maxNumberOfBoids;
    int currNumberOfBoids;

    bool nrOfBoidsChanged;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(maxNumberOfBoids < 0) maxNumberOfBoids = 0;

        while (currNumberOfBoids < maxNumberOfBoids)
        {
            spawnBoid();
            currNumberOfBoids++;
        }

        if (currNumberOfBoids > maxNumberOfBoids)
        {
            GameObject[] toBeKilled = GameObject.FindGameObjectsWithTag("Boid");
            int nrOfKillsNeeded = currNumberOfBoids - maxNumberOfBoids;
            for (int i = 0; i < nrOfKillsNeeded; i++)
            {
                if (toBeKilled[i] != null){
                    Destroy(toBeKilled[i]);
                    currNumberOfBoids--;
                }
                
            }
        }

    }

    void spawnBoid(){
        Vector2 spawnPos;
        spawnPos.x = UnityEngine.Random.Range(-camInfo.getHalfX(), camInfo.getHalfX());
        spawnPos.y = UnityEngine.Random.Range(-camInfo.getHalfY(), camInfo.getHalfY());
        float rotation = UnityEngine.Random.Range(0, 360);
        Instantiate(boid, spawnPos, Quaternion.Euler(0,0,rotation));
    }
}
