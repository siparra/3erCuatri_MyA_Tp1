using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{


    //Para el Pool
    void Initialize();
    void Dispose();

    //Para el Enemigo propio
    void Shoot();
    void Mover();
    IEnemy SetLife(int life);
    IEnemy SetSpeed(float speed);
    IEnemy SetBulletType(IBullet bullet);
    
}
