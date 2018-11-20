using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour,IEnemyBullet {

    public float speed;
    public EnemyBulletGenerator _bulletPool;
    public IBulletMovement _currentBulletMovement;

    void Update()
    {
        Move();
    }

    public void Move()
    {
        _currentBulletMovement.Move();
    }

    private void Initialize()
    {
        StartCoroutine(DestroyBullet(this));
    }

    private void Dispose()
    {
        // throw new NotImplementedException();
    }

    public static void InitializeBullet(EnemyBullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.Initialize();
    }

    public static void DisposeBullet(EnemyBullet bullet)
    {
        bullet.Dispose();
        bullet.gameObject.SetActive(false);
    }

    public void SetBulletPool(EnemyBulletGenerator bulletPool)
    {
        _bulletPool = bulletPool;
    }

    public void SetBulletMovement(IBulletMovement bulletMovement)
    {
        _currentBulletMovement = bulletMovement;
        _currentBulletMovement.SetBulletTransform(this.transform);
        _currentBulletMovement.SetBulletSpeed(speed);
        
    }

    IEnumerator DestroyBullet(EnemyBullet bullet)
    {
        yield return new WaitForSeconds(6f);
        _bulletPool.ReturnBulletToPool(bullet);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        _bulletPool.ReturnBulletToPool(this);
    }

}
