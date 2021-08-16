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
    }

    public float ExecutionTime => _executionTime;

    public void Execute()
    {
        throw new System.NotImplementedException();
    }

    public void Queue()
    {
        throw new System.NotImplementedException();
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
