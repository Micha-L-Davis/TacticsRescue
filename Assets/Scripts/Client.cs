using IntensityTable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Client : Actor, ISaveable
{
    int _perilCountdown;
    bool _imperiled = true;

    Intensity _strength = Intensity.Average;
    Intensity _fortitude = Intensity.Average;
    Intensity _coordination = Intensity.Average;
    Intensity _awareness = Intensity.Average;
    Intensity _will = Intensity.Average;
    int _maxHealth;

    bool _carryingBlock;
    bool _dropBlockNextTurn;

    enum PerilCondition
    {
        Pinned,
        Clinging,
        Disabled,
        SeekingSafety
    }
    [SerializeField]
    PerilCondition _perilStatus = PerilCondition.SeekingSafety;
    IMovable _pinnedBy;

    public int PerilCountdown => _perilCountdown;

    public bool Imperiled => _imperiled;

   

    protected override void Start()
    {
        base.Start();
        GameManager.OnTurnEnd += ProcessPeril;
        _maxHealth = (int)_strength + (int)_fortitude + (int)_coordination;
        _health = _maxHealth;
    }

    private void Update()
    {
        UpdatePerilStatus();
    }

    private void UpdatePerilStatus()
    {
        //Debug.DrawRay(transform.position, Vector3.up, Color.green);
        //Debug.DrawRay(transform.position, Vector3.down, Color.blue);
        //Debug.Log(this.name + " " + _perilStatus);
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, Vector3.up, out hitInfo, 1f))
        {
            IMovable movableObject = hitInfo.transform.GetComponent<IMovable>();
            if (movableObject != null)
            {
                _pinnedBy = movableObject;
                movableObject.IsPinning = true;
                _perilStatus = PerilCondition.Pinned;
                //move target prone and disable navmesh agent
            }
            return;
        }
        if (!Physics.Raycast(transform.position, Vector3.down, out hitInfo, 1f))
        {
            _perilStatus = PerilCondition.Clinging;
            return;
        }
        if (_health < _maxHealth / 2)
        {
            _perilStatus = PerilCondition.Disabled;
            return;
        }

        _perilStatus = PerilCondition.SeekingSafety;

        //if seeking safety, stand upright, enable navmesh agent
    }

    public void Rescue()
    {
        RecordTransformData();
        //set to child of rescuer
        //move toward local position and rotation for carry
        _imperiled = false;

    }

    public void UndoRescue()
    {
        UndoMovement();
        //set to no child
        _imperiled = true;
    }

    void ProcessPeril()
    {
        if (Imperiled)
        {
            _perilCountdown--;
            if (PerilCountdown < 1)
            {
                Debug.Log(gameObject.name + " has succumbed to peril!");
            }
        }
    }

    public void AIDeclareAction()
    {
        Outcome outcome;
        switch (_perilStatus)
        {
            case PerilCondition.Pinned:
                if (_strength > (_pinnedBy.LiftIntensity - 2))
                {
                    outcome = Dice.Roll(_strength);
                    switch (outcome)
                    {
                        case Outcome.Fail:
                            Debug.Log(name + " tried to lift the pinning object, but failed.");
                            break;
                        case Outcome.Low:
                            MovePinningBlock();
                            _carryingBlock = true;
                            _dropBlockNextTurn = true;
                            Debug.Log(name + " lifted the pinning object, but will drop it next turn.");
                            break;
                        case Outcome.Medium:
                            MovePinningBlock();
                            _carryingBlock = true;
                            Debug.Log(name + " lifted the pinning object.");
                            break;
                        case Outcome.High:
                            MovePinningBlock();
                            _carryingBlock = true;
                            _perilCountdown++;
                            Debug.Log(name + " lifted the pinning object easily.");
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Panic();
                }
                break;
            case PerilCondition.Clinging:
                outcome = Dice.Roll(_fortitude);
                switch (outcome)
                {
                    case Outcome.Fail:
                        _perilCountdown -= 2;
                        Panic();
                        break;
                    case Outcome.Low:
                        _perilCountdown--;
                        Panic();
                        break;
                    case Outcome.Medium:
                        Panic();
                        break;
                    case Outcome.High:
                        //try to climb
                        Debug.Log("Attempting to climb up");
                        //add one to peril countdown
                        break;
                    default:
                        break;
                } 
                break;
            case PerilCondition.Disabled:
                Panic();
                break;
            case PerilCondition.SeekingSafety:
                //if carrying block and drop next turn
                if (_carryingBlock && _dropBlockNextTurn)
                {
                    MovePinningBlock();
                    _carryingBlock = false;
                    return;
                }
                //drop block
                //return
                if (_carryingBlock && !_dropBlockNextTurn)
                {
                    //move a few squares
                    _dropBlockNextTurn = true;
                    return;
                }

                //check will, low: Loot | mid: panic | high: take other action
                outcome = Dice.Roll(_will);
                switch (outcome)
                {
                    case Outcome.Fail:
                        //move into danger
                        break;
                    case Outcome.Low:
                        //loot
                        break;
                    case Outcome.Medium:
                        Panic();
                        break;
                    case Outcome.High:
                        //take other action
                        Outcome o = Dice.Roll(_awareness);
                        switch (o)
                        {
                            case Outcome.Fail:
                                Panic();
                                break;
                            case Outcome.Low:
                                //move cautiously toward safety
                                break;
                            case Outcome.Medium:
                                //move swiftly toward safety
                                break;
                            case Outcome.High:
                                //if saveable object nearby
                                //if out of move range, move toward
                                //else attempt a save action
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }

    private void Panic()
    {
        Debug.Log("Client " + name + " chooses to panic!");
        GameManager.Instance.AddCommand(new PanicCommand(this, .5f));
    }

    private void MovePinningBlock()
    {
        _pinnedBy.ExecuteMove(2, this);
    }

    public override int RollInitiative()
    {
        int roll = Random.Range(0, 10);
        Debug.Log(gameObject.name + " rolls a " + roll + " for initiative.");
        return roll;
    }

    
}
