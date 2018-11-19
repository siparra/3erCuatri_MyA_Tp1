using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletGenerator : MonoBehaviour {
    public int amount;
    public EnemyBullet prefab;
    private Pool<EnemyBullet> _bulletPool;
    private int cant;

    private static EnemyBulletGenerator _instance;
    public static EnemyBulletGenerator Instance { get { return _instance; } }

    //Bullets
    private IBulletMovement _strategyBulletMovement_Normal;
    private IBulletMovement _strategyBulletMovement_Circular;

    private void Awake()
    {
        _instance = this;
        _bulletPool = new Pool<EnemyBullet>(amount, BulletFactory, EnemyBullet.InitializeBullet, EnemyBullet.DisposeBullet, true);
        cant = 1;
        
    }

    public void GetBullet(Transform Gun, int bulletMovementType)
    {
        var bullet = _bulletPool.GetObjectFromPool();
        bullet.transform.position = Gun.position;
        bullet.transform.rotation = Gun.rotation;
        switch (bulletMovementType)
        {
            case 1:
                _strategyBulletMovement_Normal = new NormalMovement();
                bullet.SetBulletMovement(_strategyBulletMovement_Normal);
                break;
            case 2:
                _strategyBulletMovement_Circular = new CircularMovement();
                bullet.SetBulletMovement(_strategyBulletMovement_Circular);
                break;
        }
        bullet.SetBulletPool(this);
    }

    private EnemyBullet BulletFactory()
    {
        return Instantiate<EnemyBullet>(prefab);
    }

    public void ReturnBulletToPool(EnemyBullet bullet)
    {
        _bulletPool.DisablePoolObject(bullet);
    }
}
