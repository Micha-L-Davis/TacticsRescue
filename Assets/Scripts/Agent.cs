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

    public void HandleMove(Vector2 mousePos)
    {
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
    }


}
