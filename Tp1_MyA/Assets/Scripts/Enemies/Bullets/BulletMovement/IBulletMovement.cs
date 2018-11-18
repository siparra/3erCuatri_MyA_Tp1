using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBulletMovement {
    void Move();

    void SetBulletSpeed(float speed);
    void SetBulletTransform(Transform transform);
}
