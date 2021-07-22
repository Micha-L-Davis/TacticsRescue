using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraIris : MonoBehaviour
{
    [SerializeField]
    GameObject _maskSphere;
    [SerializeField]
    float _speed = 5;
    public int state; //0 - idle, 1 - opening, 2 - closing
    
    void Start()
    {
        _maskSphere.transform.localScale = Vector3.zero;
        state = 1;

    }

    void Update()
    {
        ScaleIris();
    }
    public void ScaleIris()
    {
        if (state == 1) //opening
        {
            Vector3 currentScale = _maskSphere.transform.localScale;
            Vector3 newScale = new Vector3(10f, 10f, 10f);
            float addend = _speed * Time.deltaTime;
            if (newScale.x > currentScale.x)
            {
                newScale = new Vector3(currentScale.x + addend, currentScale.y + addend, currentScale.z + addend);
            }
            if (newScale.x > 10f)
            {
                newScale = new Vector3(10f, 10f, 10f);
                state = 0;
            }

            _maskSphere.transform.localScale = newScale;
        }
        else if (state == 2) //closing
        {
            Vector3 currentScale = _maskSphere.transform.localScale;
            Vector3 newScale = new Vector3(0f, 0f, 0f);
            float subtrahend = _speed * Time.deltaTime;
            if (newScale.x < currentScale.x)
            {
                newScale = new Vector3(currentScale.x - subtrahend, currentScale.y - subtrahend, currentScale.z - subtrahend);
            }
            if (newScale.x < 0f)
            {
                newScale = new Vector3(0f, 0f, 0f);
                state = 0;
            }

            _maskSphere.transform.localScale = newScale;
        }
    }
    public void ScaleIris(int newState)
    {
        state = newState;
    }
    public bool IrisInMotion()
    {
        return state == 0;
    }
}
