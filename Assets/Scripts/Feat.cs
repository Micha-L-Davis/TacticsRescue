using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feat 
{
    //custom behavior for activating an interface

    //protected Animation _animation;
    //protected AudioClip _audio;

    protected int _range;

    public int Range => _range;

    public enum ActionType
    {
        Move,
        Break,
        Save
    };
    public ActionType Action { get; private set; }

    public Feat(int range, ActionType actionType//, Animation animation, AudioClip audio
        )
    {
        //_animation = animation;
        //_audio = audio;

        _range = range;
        this.Action = actionType;
    }

}
