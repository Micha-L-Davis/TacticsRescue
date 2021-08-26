using System.Collections;
using System.Collections.Generic;
using IntensityTable;
using UnityEngine;

public abstract class Feat : ScriptableObject, IFeat
{

    //protected Animation _animation;
    //protected AudioClip _audio;

    //protected float _range;

    //public float Range => _range;

    //public enum ActionType
    //{
    //    MoveObject,
    //    BreakObject,
    //    SaveClient,
    //    Panic,
    //    Loot
    //};
    //public ActionType FeatActionType { get; private set; }

    //public Feat(float range, ActionType actionType//, Animation animation, AudioClip audio
    //    )
    //{
    //    //_animation = animation;
    //    //_audio = audio;

    //    _range = range;
    //    FeatActionType = actionType;
    //}
    public abstract float ExecutionTime { get; }
    public abstract Outcome ActionOutcome { get; }

    public abstract void Execute();
    public abstract void Queue();
    public abstract void Undo();
    public abstract void UnQueue();
}
