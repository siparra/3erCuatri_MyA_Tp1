using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisilBulletGenerator : MonoBehaviour
{

    public int amount;
    public MisilHero prefab;
    private Pool<MisilHero> _misiltPool;
    public Vector3 heroPosition;
    public GameObject smallExplotion;
    public Transform heroTransform;

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
        bullet.particleEffect = smallExplotion;
        heroPosition = GetComponent<Transform>().position;
        bullet.transform.position = heroPosition;
        bullet.heroTransform = heroTransform;
        bullet.SetBulletPool(this);
    }

    private MisilHero BulletFactory()
    {
        var bullet = Instantiate<MisilHero>(prefab);
        bullet.heroTransform = heroTransform;
        return bullet;

    }

    public void ReturnBulletToPool(MisilHero bullet)
    {
        heroPosition = GetComponent<Transform>().position;
        bullet.transform.position = heroPosition;
        _misiltPool.DisablePoolObject(bullet);
    }
}
