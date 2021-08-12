using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBreakable
{
    void Damage(int amount, IntensityTable.Intensity intensity);
    void UndoDamage(int amount, IntensityTable.Intensity intensity);
    int Integrity { get; }
    IntensityTable.Intensity MaterialResistance { get; }
}