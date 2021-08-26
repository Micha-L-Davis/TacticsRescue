using IntensityTable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Feats/Break Object")]
public class BreakObjectFeat : Feat, IFeat
{
    int _damage;
    Intensity _intensity;
    IBreakable _breakableObject;
    float _executionTime;
    Outcome _outcome;


    public BreakObjectFeat(IBreakable breakableObject, int damage, Intensity intensity, float executionTime)
    {
        _breakableObject = breakableObject;
        _damage = damage;
        _intensity = intensity;
        _executionTime = executionTime;
        Queue();
    }

    public override float ExecutionTime => _executionTime;

    public override Outcome ActionOutcome => _outcome;

    public override void Execute()
    {
        //add degreess of success based on outcome
        _breakableObject.Damage(_damage, _intensity);
    }

    public override void Queue()
    {
        GameManager.Instance.AddCommand(this);
        Debug.Log("Queueing Break Object Command");
    }

    public override void Undo()
    {
        _breakableObject.UndoDamage(_damage, _intensity);
    }

    public override void UnQueue()
    {
        //remove from queue
    }
}