using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    void ExecuteMove(int height, Hero hero);
    public void UndoMove();
}
