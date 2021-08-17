using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Client : Actor, ISaveable
{
    int _perilCountdown;
    bool _imperiled = true;

    //Rigidbody _rigidbody;
    Collider _collider;

    enum PerilCondition
    {
        Pinned,
        Clinging,
        Disabled,
        SeekingSafety
    }
    [SerializeField]
    PerilCondition _perilStatus = PerilCondition.SeekingSafety;

    public int PerilCountdown => _perilCountdown;

    public bool Imperiled => _imperiled;

   

    protected override void Start()
    {
        base.Start();
        GameManager.OnTurnEnd += ProcessPeril;
        //_rigidbody = GetComponent<Rigidbody>();
        //if (_rigidbody == null)
        //{
        //    Debug.LogError("Rigidbody component is null!");
        //}
        _collider = GetComponent<Collider>();
        if (_collider == null)
        {
            Debug.LogError("Collider component is null!");
        }
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, Vector3.up, Color.green);
        Debug.DrawRay(transform.position, Vector3.down, Color.blue);
        Debug.Log(this.name + " " + _perilStatus);
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, Vector3.up, out hitInfo, 1f))
        {
            IMovable movableObject = hitInfo.transform.GetComponent<IMovable>();
            if (movableObject != null)
            {
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
        //if health is less than half
        //peril status = "Disabled"

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
