using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable//<T> where T : Enum
{
    //void Lift(int height);
    //void Carry(Vector3 location);
    //void Drop();
    void ExecuteMove(int height, Hero hero);

    //T MovableState { get; set; }

}
