using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using UnityEngine.InputSystem.Controls;

[RequireComponent(typeof(NavMeshAgent))]
public class Agent : MonoBehaviour
{
    [SerializeField]
    Camera _camera;
    Vector3 _destination;
    [SerializeField]
    NavMeshAgent _agent;
    Input _input;

    private void Awake()
    {
        _input = new Input();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    void Start()
    {
        _input.Agent.MouseClick.performed += _ => MouseClick();
    }

    void MouseClick()
    {
        Vector2 mousePos = _input.Agent.MousePosition.ReadValue<Vector2>();
        HandleMove(mousePos);
    }


    void Update()
    {
        
    }

    private void HandleMove(Vector2 mousePos)
    {
        //cast ray from mouse position
        Ray clickRay = _camera.ScreenPointToRay(mousePos);
        RaycastHit hitInfo;
        if (Physics.Raycast(clickRay, out hitInfo))
        {
            float x = Mathf.RoundToInt(hitInfo.point.x);
            float y = Mathf.RoundToInt(hitInfo.point.y);
            float z = Mathf.RoundToInt(hitInfo.point.z);
            _destination = new Vector3(x, y, z);
            _agent.destination = _destination;
        }
        //round to nearest integer coordinate
        //assign agent destination
    }


}
