﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMovement : MonoBehaviour, IBulletMovement {

    private float _speed;
    private Transform _transform;

    public void Move()
    {
        var direction = _transform.up;
        _transform.position -= direction * _speed * Time.deltaTime;
        Debug.Log("Transform de Bullet Y: " + _transform.position.y);
        Debug.Log("Speed: " + _speed);

    }

    public void SetBulletSpeed(float speed)
    {
        _speed = speed;
    }

    public void SetBulletTransform(Transform transform)
    {
        _transform = transform;
    }
}
