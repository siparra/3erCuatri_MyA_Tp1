using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{


    //Para el Pool
    void Initialize();
    void Dispose();

    //Para el Enemigo propio
    void Attack();
    void Mover();
    void SetLife(int life);
    void SetSpeed(float speed);
    void SetBulletType(IBullet bullet);
    
}
