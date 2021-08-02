using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : Agent
{

    public override int RollInitiative()
    {
        int roll = Random.Range(0, 10);
        Debug.Log(gameObject.name + " rolls a " + roll + " for initiative.");
        return roll;
    }
}
