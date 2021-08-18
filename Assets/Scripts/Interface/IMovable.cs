using IntensityTable;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    void ExecuteMove(int height, Actor actor);
    void UndoMove();
    bool IsPinning { get; set; }
    bool IsCarried { get; }
    Intensity LiftIntensity { get; }
}
