using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Agent
{
    List<Feat> _feats;
    Feat _move;
    Feat _break;
    Feat _save;

    public Feat Move => _move;
    public Feat Break => _break;
    public Feat Save => _save;

    enum Archetype
    {
        Mental,
        Physical
    };
    [SerializeField]
    Archetype _archetype;

    protected override void Start()
    {
        base.Start();

        //mental character type constructors
        _feats = new List<Feat>();
        _move = new Feat(3, Feat.ActionType.Move);
        _feats.Add(_move);
        _break = new Feat(6, Feat.ActionType.Break);
        _feats.Add(_break);
        _save = new Feat(2, Feat.ActionType.Save);
        _feats.Add(_save);
        foreach (var feat in _feats)
        {
            Debug.Log(this.name + " " + feat.Action + " action logged.");
        }
    }


    void Update()
    {
        
    }
}
