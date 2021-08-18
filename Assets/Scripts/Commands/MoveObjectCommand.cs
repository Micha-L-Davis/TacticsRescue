using System.Collections;
using System.Collections.Generic;
using IntensityTable;
using UnityEngine;

public class MoveObjectCommand : ICommand
{
    IMovable _movableObject;
    int _height;
    Hero _hero;
    float _executionTime;
    Outcome _outcome;

    public float ExecutionTime => _executionTime;

    public Outcome ActionOutcome => _outcome;

    public MoveObjectCommand(IMovable movableObject, Outcome outcome, int height, Hero hero, float executionTime)
    {
        _movableObject = movableObject;
        _height = height;
        _hero = hero;
        _executionTime = executionTime;
        _outcome = outcome;
        Queue();
    }


    public void Execute()
    {
        if (!_movableObject.IsCarried)
        {
            switch (_outcome)
            {
                case Outcome.Fail:
                    Debug.Log("Failed to lift object!");
                    break;
                case Outcome.Low:
                    _movableObject.ExecuteMove(_height, _hero);
                    break;
                case Outcome.Medium:
                    _movableObject.ExecuteMove(_height, _hero);
                    break;
                case Outcome.High:
                    _movableObject.ExecuteMove(_height, _hero);
                    break;
                default:
                    break;
            }
        }
        else
        {
            _movableObject.ExecuteMove(_height, _hero);
        }
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
