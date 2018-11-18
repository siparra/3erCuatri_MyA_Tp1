using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBulletGenerator : MonoBehaviour
{
    public int amount;
    public BulletHero prefab;
    private Pool<BulletHero> _bulletPool;

    private static NormalBulletGenerator _instance;
    public static NormalBulletGenerator Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this;
        _bulletPool = new Pool<BulletHero>(amount, BulletFactory, BulletHero.InitializeBullet, BulletHero.DisposeBullet, true);
    }

    public void GetBullet(Transform Gun)
    {
        var bullet = _bulletPool.GetObjectFromPool();
        bullet.transform.position = Gun.position;
        bullet.transform.rotation = Gun.rotation;
        bullet.SetBulletPool(this);
    }

    private BulletHero BulletFactory()
    {
        return Instantiate<BulletHero>(prefab);
    }

    public void ReturnBulletToPool(BulletHero bullet)
    {
        _bulletPool.DisablePoolObject(bullet);
    }

}
