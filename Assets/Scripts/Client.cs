using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : Actor, ISaveable
{
    int _perilCountdown;
    bool _imperiled = true;
    Rigidbody _rigidbody;


    public int PerilCountdown => _perilCountdown;

    public bool Imperiled => _imperiled;

    protected override void Start()
    {
        base.Start();
        GameManager.OnTurnEnd += ProcessPeril;
        _rigidbody = GetComponent<Rigidbody>();
        if (_rigidbody == null)
        {
            Debug.LogError("Rigidbody component is null!");
        }
    }

    private void Update()
    {
        //raycast (global)up to detect movable objects
        //if movable object is above me, peril status is "pinned"
        //raycast (global)down to detect if grounded
        //if not grounded, peril status is "clinging"
        //if not pinned and not clinging, peril status is seeking safety
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
        //switch on peril status
        //Pinned:
            //if strength greater than (lift intensity - 2), try to lift
            //else panic
        //Clinging:
            //check endurance, low: perilCountdown-2, panic | mid: perilCountdown-1, panic | high: if strength greater than climb intensity-2, try to climb 
        //Seeking Safety
            //check will, low: Loot | mid: panic | high: take other action
            //check awareness, low: panic | mid: move to safety | high: if saveable object nearby, move toward or attempt to save
    }

    public override int RollInitiative()
    {
        int roll = Random.Range(0, 10);
        Debug.Log(gameObject.name + " rolls a " + roll + " for initiative.");
        return roll;
    }


}
