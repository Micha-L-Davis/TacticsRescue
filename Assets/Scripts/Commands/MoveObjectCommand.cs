using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectCommand : ICommand
{
    IMovable _movableObject;
    int _height;
    Hero _hero;

    public MoveObjectCommand(IMovable movableObject, int height, Hero hero)
    {
        _movableObject = movableObject;
        _height = height;
        _hero = hero;
        Queue();
    }


    public void Execute()
    {
        _movableObject.ExecuteMove(_height, _hero);
    }

    public void Queue()
    {
        GameManager.Instance.AddCommand(this);
        Debug.Log("Queueing Move Object Command");
    }

    public void UnQueue()
    {
        //remove this from the command manager list
    }

    public void Undo()
    {
        _movableObject.UndoMove();
    }
}
