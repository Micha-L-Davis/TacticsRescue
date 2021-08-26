using System.Collections;
using System.Collections.Generic;
using IntensityTable;
using UnityEngine;

[CreateAssetMenu(menuName = "Feats/Panic")]
public class PanicFeat : Feat, IFeat
{
    Actor _actor;
    float _executionTime;

    public PanicFeat(Actor actor, float executionTime)
    {
        _actor = actor;
        _executionTime = executionTime;
    }

    public override float ExecutionTime => _executionTime;

    public override Outcome ActionOutcome => throw new System.NotImplementedException();

    public override void Execute()
    {
        Debug.Log(_actor.name + ": HEEEEEELLLLLLP MEEEEEEEEE!!!");
    }

    public override void Queue()
    {
        GameManager.Instance.AddCommand(this);
        Debug.Log("Queueing Panic Command");
    }

    public override void Undo()
    {
        throw new System.NotImplementedException();
    }

    public override void UnQueue()
    {
        throw new System.NotImplementedException();
    }
}
