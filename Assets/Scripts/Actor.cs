using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using UnityEngine.InputSystem.Controls;
using System;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Actor : MonoBehaviour
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
        _previousPosition = transform.position;
        _previousRotation = transform.rotation;
        Debug.Log("Moving to " + destination);
        _agent.destination = destination;
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
}
