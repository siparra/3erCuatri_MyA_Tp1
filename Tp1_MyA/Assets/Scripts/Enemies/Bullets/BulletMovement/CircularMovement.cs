using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour, IBulletMovement {
    private float _speed;
    private Transform _transform;
    private Vector3 startPosition;
    private float timer;

    public void Move()
    {
        if (timer < 0)
            timer = 360f;
        timer -= Time.deltaTime;

        var rad = timer * Mathf.Deg2Rad;
        _transform.position = startPosition + new Vector3(Mathf.Sin(rad * 100f) * 2f, 0, 0);
        _transform.position += new Vector3(0, -0.06f, 0);
        startPosition.y = _transform.position.y;
    }

    public void SetBulletSpeed(float speed)
    {
        _speed = speed;
    }

    public void SetBulletTransform(Transform transform)
    {
        _transform = transform;
        startPosition = transform.position;
    }
}
