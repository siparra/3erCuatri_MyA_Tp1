using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinuousAdvance : MonoBehaviour, IMovement {

    private float _speed;
    private float _lateralSpeed;
    private Transform _transform;
    private float timer;
    private Vector3 startPosition;

    public SinuousAdvance(float speed, float lateralSpeed, Transform transform)
    {
        _speed = speed;
        _lateralSpeed = lateralSpeed;
        _transform = transform;
        startPosition = _transform.position;
        timer = 360f;
    }

    public void Advance()
    {
        if (timer < 0)
            timer = 360f;
        timer -= Time.deltaTime;

        var rad = timer * Mathf.Deg2Rad;
        _transform.position = startPosition + new Vector3(Mathf.Sin(rad*100f)*10f, 0, 0);
        _transform.position += new Vector3(0, - 0.02f, 0);
        startPosition.y = _transform.position.y;
    }
}
