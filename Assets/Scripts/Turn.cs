using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn
{
    public object[] action = new object[2];
    public List<object[]> actionList = new List<object[]>();
    public Turn(Feat feat, Vector3 location)
    {
        action[0] = feat;
        action[1] = location;
    }

    public  Turn(Feat feat, IMovable movableObj)
    {
        action[0] = feat;
        action[1] = movableObj;
    }

    //public Turn(Feat feat, IBreakable breakableObj)
    //{
        //action[0] = feat;
        //action[1] = breakableObj;
    //}

    //public Turn(Feat feat, ISaveable saveableObj)
    //{
        //action[0] = feat;
        //action[1] = saveableObj;
    //}
}
