using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using UnityEngine.InputSystem.Controls;
using System;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Actor : MonoBehaviour, IBreakable
{
    [SerializeField]
    Camera _camera;
    protected Vector3 _destination;
    protected Vector3 _previousPosition;
    protected Quaternion _previousRotation;
    protected NavMeshAgent _agent;
    public Sprite portrait;
    public Hero hero;
    public Client client;
    public bool IsHero { get; private set; }
    [SerializeField]
    int _health;
    [SerializeField]
    IntensityTable.Intensity _bodyResistance = IntensityTable.Intensity.Average;
    public int Integrity => _health;
    public IntensityTable.Intensity MaterialResistance => _bodyResistance;

    protected virtual void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        if (_agent == null)
        {
            Debug.LogError("NavMeshAgent is NULL!");
        }

        GameManager.OnRoundStart += RollInitiative;
        TryGetComponent<Hero>(out hero);
        if (hero != null)
        {
            IsHero = true;
        }
        TryGetComponent<Client>(out client);
    }

    public void ExecuteMovement(Vector3 destination)
    {
        Debug.Log(transform.name + " moving to " + destination);
        _destination = destination;
        RecordTransformData();
        Debug.Log("Moving to " + destination);
        _agent.destination = destination;
    }

    protected void RecordTransformData()
    {
        _previousPosition = transform.position;
        _previousRotation = transform.rotation;
    }

    public void UndoMovement()
    {
        transform.SetPositionAndRotation(_previousPosition, _previousRotation);
    }

    public abstract int RollInitiative();

    public bool MovementComplete()
    {
        float distance = Vector3.Distance(transform.position, _destination);
        return distance <= 1.4f;
    }
    public void Damage(int amount, IntensityTable.Intensity intensity)
    {
        if (intensity > _bodyResistance)
        {
            _health -= amount;
        }
        else
        {
            int a = amount - (int)_bodyResistance;
            _health -= a;
        }
    }

    public void UndoDamage(int amount, IntensityTable.Intensity intensity)
    {
        if (intensity > _bodyResistance)
        {
            _health += amount;
        }
        else
        {
            int amt = amount - (int)_bodyResistance;
            _health += amt;
        }
    }
}
