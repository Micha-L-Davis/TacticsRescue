using System.Collections;
using System.Collections.Generic;
using IntensityTable;
using UnityEngine;

public class ActorMovementCommand : ICommand
{
    Actor _actor;
    Vector3 _destination;

    public ActorMovementCommand(Actor actor, Vector3 destination)
    {
        _actor = actor;
        _destination = destination;
        Queue();
    }

    public float ExecutionTime => throw new System.NotImplementedException();

    public Outcome ActionOutcome => throw new System.NotImplementedException();

    public void Execute()
    {
        _actor.ExecuteMovement(_destination);
    }

    public void Queue()
    {
        GameManager.Instance.AddCommand(this);
        Debug.Log("Queueing Actor Movement Command");
    }

    public void Undo()
    {
        _actor.UndoMovement();
    }

    public void UnQueue()
    {
        //remove from command list
    }
}
