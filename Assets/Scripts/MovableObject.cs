using System.Collections;
using System.Collections.Generic;
using IntensityTable;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovableObject : MonoBehaviour, IMovable
{
    Rigidbody _rigidbody;
    float _speed = 5;
    bool _isLifting;
    Vector3 _height;
    GameObject _parent;
    bool _isCarried;
    Vector3 _previousPosition;
    Quaternion _previousRotation;
    [SerializeField]
    Intensity _liftIntensity;

    public bool IsPinning { get; set; } //use this to alter the color of the object when highlighted or selected

    public Intensity LiftIntensity => _liftIntensity;
    public bool IsCarried => _isCarried;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _parent = transform.parent.gameObject;
    }

    private void Update()
    {
        if (_isLifting)
        {
            transform.position = Vector3.MoveTowards(transform.position, _height, _speed * Time.deltaTime);
        }
        if (transform.position == _height)
        {
            _isLifting = false;
            _isCarried = true;
        }
    }

    public void ExecuteMove(int height, Actor actor)
    {
        _previousPosition = transform.position;
        _previousRotation = transform.rotation;
        if (!_isLifting && !_isCarried)
        { 
            Debug.Log("Lifting " + this.name);
            _rigidbody.isKinematic = true;
            _height = new Vector3(transform.position.x, Mathf.RoundToInt(transform.position.y + height), transform.position.z);
            _isLifting = true;
            transform.parent = actor.transform;
        }
        else if(_isCarried)
        {
            _rigidbody.isKinematic = false;
            transform.parent = _parent.transform;
            _isLifting = false;
        }
    }
    public void UndoMove()
    {
        if (_isCarried)
        {
            transform.SetPositionAndRotation(_previousPosition, _previousRotation);
            _rigidbody.isKinematic = false;
            _isLifting = false;
            _isCarried = false;
        }
        else
        {
            _rigidbody.isKinematic = true;
            _isCarried = true;
            transform.SetPositionAndRotation(_previousPosition, _previousRotation);
        }

    }
}
