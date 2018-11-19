using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAdvance : MonoBehaviour, IMovement {
    private float _speed;
    private Transform _transform;
    private Vector3 direction;

    public NormalAdvance(float speed,Transform transform)
    {
        _speed = speed;
        _transform = transform;
    }

    public void Advance()
    {
        
        if(_transform.position.y < -2f)
        {
            direction = Vector3.up;
        }

        if(_transform.position.y> 10)
        {
            direction = Vector3.down;
        }
        _transform.position += direction * _speed * Time.deltaTime;
    }
}
