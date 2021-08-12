using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanicCommand : ICommand
{
    Actor _actor;
    float _executionTime;

    public PanicCommand(Actor actor, float executionTime)
    {
        _actor = actor;
        _executionTime = executionTime;
    }

    public float ExecutionTime => _executionTime;

    public void Execute()
    {
        Debug.Log(_actor.name + ": HEEEEEELLLLLLP MEEEEEEEEE!!!");
    }

    public void Queue()
    {
        GameManager.Instance.AddCommand(this);
        Debug.Log("Queueing Panic Command");
    }

    public void Undo()
    {
        throw new System.NotImplementedException();
    }

    public void UnQueue()
    {
        throw new System.NotImplementedException();
    }
}
