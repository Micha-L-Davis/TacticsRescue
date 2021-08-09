using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feat 
{
    //protected Animation _animation;
    //protected AudioClip _audio;

    protected float _range;

    public float Range => _range;

    public enum ActionType
    {
        MoveObject,
        BreakObject,
        SaveClient,
        Panic,
        Loot
    };
    public ActionType FeatActionType { get; private set; }

    public Feat(float range, ActionType actionType//, Animation animation, AudioClip audio
        )
    {
        //_animation = animation;
        //_audio = audio;

        _range = range;
        FeatActionType = actionType;
    }

}
