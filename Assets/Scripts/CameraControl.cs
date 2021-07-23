using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    Input _input;
    [SerializeField]
    float _speed;
    Vector2 _panVector;

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
        _input.Camera.Pan.performed += context => PanCamera(context);
        _input.Camera.Rotate.performed += context => RotateCamera(context);
        _input.Camera.Elevate.performed += context => ElevateCamera(context);
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x + _panVector.x, transform.position.y, transform.position.z + _panVector.y) * _speed * Time.deltaTime;
    }

    void PanCamera(InputAction.CallbackContext context)
    {
        _panVector = context.ReadValue<Vector2>();
    }

    void RotateCamera(InputAction.CallbackContext context)
    {

    }

    void ElevateCamera(InputAction.CallbackContext context)
    {

    }
}
