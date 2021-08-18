using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IntensityTable;

public class BreakableObject : MonoBehaviour, IBreakable
{
    [SerializeField]
    Intensity _materialResistance;
    [SerializeField]
    int _integrity = 1;
    public Intensity MaterialResistance => _materialResistance;
    public int Integrity => _integrity;

    public void Damage(int amount, Intensity intensity)
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
        if (_integrity < 1)
        {
            gameObject.SetActive(false);
        }
    }

    public void UndoDamage(int amount, Intensity intensity)
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
