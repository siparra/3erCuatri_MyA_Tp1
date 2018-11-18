using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletGenerator : MonoBehaviour {
    public int amount;
    public EnemyBullet prefab;
    private Pool<EnemyBullet> _bulletPool;

    private static EnemyBulletGenerator _instance;
    public static EnemyBulletGenerator Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this;
        _bulletPool = new Pool<EnemyBullet>(amount, BulletFactory, EnemyBullet.InitializeBullet, EnemyBullet.DisposeBullet, true);
    }

    public void GetBullet(Transform Gun, IBulletMovement bulletMovement)
    {
        var bullet = _bulletPool.GetObjectFromPool();
        bullet.transform.position = Gun.position;
        bullet.transform.rotation = Gun.rotation;
        bullet.SetBulletMovement(bulletMovement);
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
