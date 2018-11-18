using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAdvance : MonoBehaviour, IMovement {
    private float _speed;
    private Transform _transform;


    public NormalAdvance(float speed,Transform transform)
    {
        _speed = speed;
        _transform = transform;
    }

    public void Advance()
    {
        _transform.position += Vector3.down * _speed * Time.deltaTime;
    }
}
