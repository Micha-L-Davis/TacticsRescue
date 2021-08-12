using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour, IBreakable
{
    [SerializeField]
    IntensityTable.Intensity _materialResistance;
    [SerializeField]
    int _integrity;
    public IntensityTable.Intensity MaterialResistance => _materialResistance;
    public int Integrity => _integrity;

    public void Damage(int amount, IntensityTable.Intensity intensity)
    {
        if (intensity > MaterialResistance)
        {
            _integrity -= amount;
        }
        else
        {
            int a = amount - (int)MaterialResistance;
            _integrity -= a;
        }
    }

    public void UndoDamage(int amount, IntensityTable.Intensity intensity)
    {
        if (intensity > MaterialResistance)
        {
            _integrity += amount;
        }
        else
        {
            int a = amount - (int)MaterialResistance;
            _integrity += a;
        }
    }
}
