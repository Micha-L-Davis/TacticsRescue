using System.Collections;
using System.Collections.Generic;
using IntensityTable;
using UnityEngine;

[CreateAssetMenu(menuName = "Feats/Save Object")]
public class SaveObjectFeat : Feat, IFeat
{
    ISaveable _saveableObject;
    int _executionTime;
    Outcome _outcome;
    public SaveObjectFeat(ISaveable saveableObject, int executionTime)
    {
        _saveableObject = saveableObject;
        _executionTime = executionTime;
        Queue();
    }

    public override float ExecutionTime => _executionTime;

    public override Outcome ActionOutcome => _outcome;

    public override void Execute()
    {
        //add degrees of success based on outcome
        _saveableObject.Rescue();
    }

    public override void Queue()
    {
        GameManager.Instance.AddCommand(this);
        Debug.Log("Queueing Save Object Command");
    }

    public override void Undo()
    {
        _saveableObject.UndoRescue();
    }

    public override void UnQueue()
    {
        //remove this from the command manager list
    }

}
