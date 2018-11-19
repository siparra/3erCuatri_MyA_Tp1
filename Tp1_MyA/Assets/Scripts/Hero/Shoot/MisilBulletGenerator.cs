using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisilBulletGenerator : MonoBehaviour
{

    public int amount;
    public MisilHero prefab;
    private Pool<MisilHero> _misiltPool;

    private static MisilBulletGenerator _instance;
    public static MisilBulletGenerator Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this;
        _misiltPool = new Pool<MisilHero>(amount, BulletFactory, MisilHero.InitializeBullet, MisilHero.DisposeBullet, true);
    }

    public void GetBullet(Transform Gun)
    {
        var bullet = _misiltPool.GetObjectFromPool();
        bullet.transform.position = Gun.position;
        bullet.transform.rotation = Gun.rotation;
        bullet.SetBulletPool(this);
    }

    private MisilHero BulletFactory()
    {
        return Instantiate<MisilHero>(prefab);
    }

    public void ReturnBulletToPool(MisilHero bullet)
    {
        _misiltPool.DisablePoolObject(bullet);
    }
}
