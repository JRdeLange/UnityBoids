using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidID : MonoBehaviour
{

    int ID;

    // Start is called before the first frame update
    void Start()
    {
        BoidIDGiver boidIDGiver = FindObjectOfType<BoidIDGiver>();
        ID = boidIDGiver.getNewBoidID();
    }

    public int getID(){
        return ID;
    }
}
