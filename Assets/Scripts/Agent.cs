using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using UnityEngine.InputSystem.Controls;
using System;

[RequireComponent(typeof(NavMeshAgent))]
public class Agent : MonoBehaviour
{
    [SerializeField]
    Camera _camera;
    protected Vector3 _destination;
    protected NavMeshAgent _agent;

    protected virtual void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        if (_agent == null)
        {
            Debug.LogError("NavMeshAgent is NULL!");
        }
    }

    public void HandleMove(Vector2 mousePos)
    {
        Ray clickRay = _camera.ScreenPointToRay(mousePos);
        RaycastHit hitInfo;
        if (Physics.Raycast(clickRay, out hitInfo))
        {
            Debug.Log(hitInfo.point);
            float x = Mathf.RoundToInt(hitInfo.point.x);
            float y = Mathf.RoundToInt(hitInfo.point.y);
            float z = Mathf.RoundToInt(hitInfo.point.z);
            _destination = new Vector3(x, y, z);
            Debug.Log(_destination);
            _agent.destination = _destination;
        }
    }


}
