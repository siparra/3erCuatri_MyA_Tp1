using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHero : MonoBehaviour
{
    public float speed;
    private NormalBulletGenerator _bulletPool;

    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        var direction = transform.up;
        transform.position += direction * speed * Time.deltaTime;
    }

    private void Initialize()
    {
        StartCoroutine(DestroyBullet(this));
    }
    
    private void Dispose()
    {
       // throw new NotImplementedException();
    }

    public static void InitializeBullet(BulletHero bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.Initialize();
    }

    public static void DisposeBullet(BulletHero bullet)
    {
        bullet.Dispose();
        bullet.gameObject.SetActive(false);
    }

    public void SetBulletPool(NormalBulletGenerator bulletPool)
    {
        _bulletPool = bulletPool;
    }

    IEnumerator DestroyBullet(BulletHero bullet)
    {
        yield return new WaitForSeconds(3f);
       // BulletHero.DisposeBullet(bullet);
        _bulletPool.ReturnBulletToPool(bullet);
    }

    public void OnCollisionEnter(Collision collision)
    {
        _bulletPool.ReturnBulletToPool(this);
    }
}
