using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovableBlock : MonoBehaviour, IMovable//<MovableBlock.MovementState>
{
    Rigidbody _rigidbody;
    float _speed = 5;
    bool _isLifting;
    Vector3 _height;
    GameObject _parent;
    bool _isCarried;

    //public MovementState MovableState
    //{
    //    get { return _movableState; }
    //    set { _movableState = value; }
    //}

    //public enum MovementState
    //{
    //    Grounded,
    //    Lifted,
    //    Carried
    //};
    //[SerializeField]
    //MovementState _movableState;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _parent = transform.parent.gameObject;
        //MovableState = MovementState.Grounded;
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
        //if (MovableState == MovementState.Carried)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, _location, _speed * Time.deltaTime);
        //}
    }

    //public void Carry(Vector3 location)
    //{
    //    MovableState = MovementState.Carried;
    //    location = _location;
    //    //turn on carry wobble animation
    //}

    //public void Drop()
    //{

    //    //MovableState = MovementState.Grounded;
    //    //put some particles here
    //}

    //public void Lift(int height)
    //{


    //    //MovableState = MovementState.Lifted;
    //    //turn on lift animation
    //    //add particles
    //}

    public void ExecuteMove(int height, Hero hero)
    {
        if (!_isLifting && !_isCarried)
        { 
            Debug.Log("Lifting " + this.name);
            _rigidbody.isKinematic = true;
            _height = new Vector3(transform.position.x, Mathf.RoundToInt(transform.position.y + height), transform.position.z);
            _isLifting = true;
            transform.parent = hero.transform;
        }
        else if(_isCarried)
        {
            _rigidbody.isKinematic = false;
            transform.parent = _parent.transform;
            _isLifting = false;
        }


        //switch (MovableState)
        //{
        //    case MovementState.Grounded:
        //        Lift(height);
        //        break;
        //    case MovementState.Lifted:
        //        Carry(location);
        //        break;
        //    case MovementState.Carried:
        //        Drop();
        //        break;
        //    default:
        //        break;
        //}
    }
}
