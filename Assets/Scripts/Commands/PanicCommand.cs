using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanicCommand : ICommand
{
    Actor _actor;

    public PanicCommand(Actor actor)
    {
        _actor = actor;
    }

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
