using System.Collections;
using System.Collections.Generic;
using IntensityTable;
using UnityEngine;

[CreateAssetMenu(menuName = "Feats/Actor Movement")]
public class ActorMovementFeat : Feat, IFeat
{
    Actor _actor;
    Vector3 _destination;

    public ActorMovementFeat(Actor actor, Vector3 destination)
    {
        _actor = actor;
        _destination = destination;
        Queue();
    }

    public override float ExecutionTime => throw new System.NotImplementedException();

    public override Outcome ActionOutcome => throw new System.NotImplementedException();

    public override void Execute()
    {
        _actor.ExecuteMovement(_destination);
    }

    public override void Queue()
    {
        GameManager.Instance.AddCommand(this);
        Debug.Log("Queueing Actor Movement Command");
    }

    public override void Undo()
    {
        _actor.UndoMovement();
    }

    public override void UnQueue()
    {
        //remove from command list
    }
}
