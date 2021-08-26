using System.Collections;
using System.Collections.Generic;
using IntensityTable;
using UnityEngine;

[CreateAssetMenu(menuName = "Feats/Move Object")]
public class MoveObjectFeat : Feat, IFeat
{
    IMovable _movableObject;
    int _height;
    Hero _hero;
    float _executionTime;
    Outcome _outcome;

    public override float ExecutionTime => _executionTime;

    public override Outcome ActionOutcome => _outcome;

    public MoveObjectFeat(IMovable movableObject, Outcome outcome, int height, Hero hero, float executionTime)
    {
        _movableObject = movableObject;
        _height = height;
        _hero = hero;
        _executionTime = executionTime;
        _outcome = outcome;
        Queue();
    }


    public override void Execute()
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

    public override void Queue()
    {
        GameManager.Instance.AddCommand(this);
        Debug.Log("Queueing Move Object Command");
    }

    public override void UnQueue()
    {
        //remove this from the command manager list
    }

    public override void Undo()
    {
        _movableObject.UndoMove();
    }
}
