using IntensityTable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Actor
{
    //List<Feat> _feats = new List<Feat>();


    [SerializeField]
    HeroData _heroData;

    public string HeroName
    {
        get
        {
            return _heroData.heroName;
        }
    }
    public Intensity Strength
    {
        get
        {
            return _heroData.strength;
        }

        private set
        {
            _heroData.strength = value;
        }
    }
    public Intensity Fortitude
    {
        get
        {
            return _heroData.fortitude;
        }

        private set
        {
            _heroData.fortitude = value;
        }
    }
    public Intensity Coordination
    {
        get
        {
            return _heroData.coordination;
        }

        private set
        {
            _heroData.coordination = value;
        }
    }
    public Intensity Awareness
    {
        get
        {
            return _heroData.awareness;
        }

        private set
        {
            _heroData.awareness = value;
            InitiativeBonus = Mathf.FloorToInt((int)Awareness / 10);
        }
    }
    public Intensity Will
    {
        get
        {
            return _heroData.will;
        }

        private set
        {
            _heroData.will = value;
        }
    }

    public int InitiativeBonus
    {
        get
        {
            return _heroData.initiativeBonus;
        }

        private set
        {
            _heroData.initiativeBonus = value;
        }
    }



    public HeroData.HeroicOrigin HeroicOrigin
    {
        get
        {
            return _heroData.heroicOrigin;
        }
    }

    //enum Archetype
    //{
    //    Mental,
    //    Physical
    //};
    //[SerializeField]
    //Archetype _archetype;

    protected override void Start()
    {
        base.Start();

        //mental character type constructors
        //get these tied to attributes rather than magic numbers
        //_feats = new List<Feat>();
        //_move = new Feat(3.51f, Feat.ActionType.MoveObject);
        //_feats.Add(_move);
        //_break = new Feat(6.51f, Feat.ActionType.BreakObject);
        //_feats.Add(_break);
        //_save = new Feat(1.51f, Feat.ActionType.SaveClient);
        //_feats.Add(_save);
        foreach (var feat in _feats)
        {
            Debug.Log(this.name + " " + feat + " action logged.");
        }

    }



    private void Awake()
    {
        _heroData.SetMaxHealth();
        _heroData.SetInitiativeBonus();
        _health = _heroData.maxHealth;
    }

    public override void RollInitiative()
    {
        int roll = Random.Range(0, 10);
        roll += InitiativeBonus;
        Debug.Log(HeroName + " rolls a " + roll + " for initiative.");
        initiative = roll;
    }

    private void AttemptAction(Intensity attribute, IFeat action)
    {
        Outcome outcome = Dice.Roll(attribute);
        switch (outcome)
        {
            case Outcome.Fail:
                break;
            case Outcome.Low:
                break;
            case Outcome.Medium:
                break;
            case Outcome.High:
                break;
            default:
                break;
        }
    }
}
