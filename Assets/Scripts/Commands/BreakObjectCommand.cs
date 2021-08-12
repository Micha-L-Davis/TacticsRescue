using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObjectCommand : ICommand
{
    int _damage;
    IntensityTable.Intensity _intensity;
    BreakableObject _breakableObject;
    float _executionTime;


    public BreakObjectCommand(int damage, IntensityTable.Intensity intensity, float executionTime)
    {
        _damage = damage;
        _intensity = intensity;
        _executionTime = executionTime;
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