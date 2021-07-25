using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    Input _input;
    [SerializeField]
    float _panSpeed = 5;
    [SerializeField]
    float _rotationSpeed = 25;
    Vector2 _panInput;
    float _rotationInput;
    [SerializeField]
    Camera _camera;
    float _viewPositionX, _viewPositionY, _viewWidth, _viewHeight;
    [SerializeField]
    float _maxZoom = 9f;
    [SerializeField]
    float _minZoom = 3f;
    [SerializeField]
    float _baseZoom = 6f;
    [SerializeField]
    int _currentElevation = 1;
    [SerializeField]
    int _maxElevation = 10;
    [SerializeField]
    int _minElevation = 1;

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
        SetInitialZoom();
    }

    private void SetInitialZoom()
    {
        _viewPositionX = 0;
        _viewPositionY = 0;
        _viewWidth = 1;
        _viewHeight = 1;

        _camera.enabled = true;

        _camera.orthographicSize = _baseZoom;
    }

    private void SubscribeToInputEvents()
    {
        _input.Camera.Pan.started += context => OnPanCamera(context);
        _input.Camera.Pan.performed += context => OnPanCamera(context);
        _input.Camera.Pan.canceled += context => OnPanCamera(context);

        _input.Camera.Rotate.started += context => OnRotateCamera(context);
        _input.Camera.Rotate.performed += context => OnRotateCamera(context);
        _input.Camera.Rotate.canceled += context => OnRotateCamera(context);

        _input.Camera.Elevate.performed += context => OnElevateCamera(context);

        _input.Camera.Zoom.performed += context => OnZoomCamera(context);
    }

    void LateUpdate()
    {
        UpdateTranslation();
        UpdateRotation();
        UpdateZoom();
    }

    private void UpdateZoom() => _camera.rect = new Rect(_viewPositionX, _viewPositionY, _viewWidth, _viewHeight);

    private void UpdateRotation() => transform.Rotate(transform.up, _rotationInput * _rotationSpeed * Time.deltaTime);

    private void UpdateTranslation()
    {
        transform.Translate(Vector3.right * _panInput.x * _panSpeed * Time.deltaTime, Space.Self);
        transform.Translate(Vector3.forward * _panInput.y * _panSpeed * Time.deltaTime, Space.Self);
    }

    void OnPanCamera(InputAction.CallbackContext context) => _panInput = context.ReadValue<Vector2>();

    void OnRotateCamera(InputAction.CallbackContext context) => _rotationInput = context.ReadValue<float>();

    void OnElevateCamera(InputAction.CallbackContext context)
    {
        float elevationInput = context.ReadValue<float>();
        if (elevationInput > 0 && _currentElevation < _maxElevation)
        {
            _currentElevation++;
            transform.position = new Vector3(transform.position.x, _currentElevation, transform.position.z);
        }
        else if (elevationInput < 0 && _currentElevation > _minElevation)
        {
            _currentElevation--;
            transform.position = new Vector3(transform.position.x, _currentElevation, transform.position.z);
        }
    }

    void OnZoomCamera(InputAction.CallbackContext context)
    {
        float zoomInput = context.ReadValue<float>();
        if (zoomInput > 0 && _camera.orthographicSize < _maxZoom)
        {
            _camera.orthographicSize++;
        }
        else if (zoomInput < 0 && _camera.orthographicSize > _minZoom)
        {
            _camera.orthographicSize--;
        }
    }
}
