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
        SubscribeToInputEvents();
    }

    private void SubscribeToInputEvents()
    {
        _input.Camera.Pan.started += context => PanCamera(context);
        _input.Camera.Pan.performed += context => PanCamera(context);
        _input.Camera.Pan.canceled += context => PanCamera(context);
        _input.Camera.Rotate.performed += context => RotateCamera(context);
        _input.Camera.Elevate.performed += context => ElevateCamera(context);
    }

    void Update()
    {
        transform.Translate(Vector3.right * _panVector.x * _speed * Time.deltaTime, Space.Self);
        transform.Translate(Vector3.forward * _panVector.y * _speed * Time.deltaTime, Space.Self);
    }

    void PanCamera(InputAction.CallbackContext context)
    {
        _panVector = context.ReadValue<Vector2>();
        Debug.Log("Pan vector = " + _panVector);
    }

    void RotateCamera(InputAction.CallbackContext context)
    {

    }

    void ElevateCamera(InputAction.CallbackContext context)
    {

    }
}
