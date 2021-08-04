using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn
{
    public object[] action = new object[2];
    public List<object[]> actionList = new List<object[]>();
    public void AddAction(object target, Feat feat = null)
    {
        action[0] = feat;
        action[1] = target;
        actionList.Add(action);
    }
    public void AddAction(Feat feat, object target = null)
    {
        action[0] = feat;
        action[1] = target;
        actionList.Add(action);
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
