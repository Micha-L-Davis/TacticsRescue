using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    Agent _selectedAgent;

    Input _input;
    [SerializeField]
    Camera _camera;

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

    private void Start()
    {
        _input.Agent.Select.performed += _ => SelectAgent();
        _input.Agent.Execute.performed += _ => Execute();
    }

    void SelectAgent()
    {
        Debug.Log("Left Click performed");
        Vector2 mousePos = _input.Agent.MousePosition.ReadValue<Vector2>();
        Ray clickRay = _camera.ScreenPointToRay(mousePos);
        RaycastHit hitInfo;
        if (Physics.Raycast(clickRay, out hitInfo))
        {
            Debug.Log(hitInfo.transform.name + " hit by ray");
            Agent agent = hitInfo.transform.gameObject.GetComponent<Agent>();
            if (agent != null)
            {
                _selectedAgent = agent;
                Debug.Log(_selectedAgent.name + " selected.");
                return;
            }
        }
        Debug.Log("Selecting null");
        _selectedAgent = null;
    }

    void Execute()
    {
        Debug.Log("Right Click performed");
        if (_selectedAgent != null)
        {
            Debug.Log(_selectedAgent.name + " executing movement.");
            Vector2 mousePos = _input.Agent.MousePosition.ReadValue<Vector2>();
            _selectedAgent.HandleMove(mousePos);
        }
    }
}
