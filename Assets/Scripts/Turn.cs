using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn
{
    public LinkedList<object[]> actionList = new LinkedList<object[]>();
    public void AddAction(object target, Feat feat = null)
    {
        object[] action = new object[2];
        action[0] = feat;
        action[1] = target;
        actionList.AddLast(action);
    }
    public void AddAction(Feat feat, object target = null)
    {
        object[] action = new object[2];
        action[0] = feat;
        action[1] = target;
        actionList.AddLast(action);
    }
}
