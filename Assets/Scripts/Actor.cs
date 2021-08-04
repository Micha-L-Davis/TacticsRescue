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

    public void HandleMove(Vector3 destination)
    {

            Debug.Log(_destination);
            _agent.destination = _destination;

    }

    public abstract int RollInitiative();

}
