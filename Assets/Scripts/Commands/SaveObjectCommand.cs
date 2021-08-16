using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObjectCommand : ICommand
{
    ISaveable _saveableObject;
    int _executionTime;
    public SaveObjectCommand(ISaveable saveableObject, int executionTime)
    {
        _saveableObject = saveableObject;
        _executionTime = executionTime;
        Queue();
    }

    public float ExecutionTime => _executionTime;

    public void Execute()
    {
        _saveableObject.Rescue();
    }

    public void Queue()
    {
        GameManager.Instance.AddCommand(this);
        Debug.Log("Queueing Save Object Command");
    }

    public void Undo()
    {
        _saveableObject.UndoRescue();
    }

    public void UnQueue()
    {
        //remove this from the command manager list
    }

}
