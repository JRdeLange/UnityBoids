using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidIDGiver : MonoBehaviour
{

    int boidID = 0;

    public int getNewBoidID(){
        boidID++;
        return boidID - 1;
    }

    
}
