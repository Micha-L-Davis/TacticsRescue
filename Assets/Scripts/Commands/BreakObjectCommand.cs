using IntensityTable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObjectCommand : ICommand
{
    int _damage;
    Intensity _intensity;
    IBreakable _breakableObject;
    float _executionTime;


    public BreakObjectCommand(IBreakable breakableObject, int damage, Intensity intensity, float executionTime)
    {
        _breakableObject = breakableObject;
        _damage = damage;
        _intensity = intensity;
        _executionTime = executionTime;
        Queue();
    }

    public float ExecutionTime => _executionTime;

    public void Execute()
    {
        _breakableObject.Damage(_damage, _intensity);
    }

    public void Queue()
    {
        GameManager.Instance.AddCommand(this);
        Debug.Log("Queueing Break Object Command");
    }

    public void Undo()
    {
        _breakableObject.UndoDamage(_damage, _intensity);
    }

    public void UnQueue()
    {
        //remove from queue
    }
}