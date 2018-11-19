using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisilHero : MonoBehaviour {

    public float speed;
    private MisilBulletGenerator _bulletPool;

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

    public static void InitializeBullet(MisilHero bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.Initialize();
    }

    public static void DisposeBullet(MisilHero bullet)
    {
        bullet.Dispose();
        bullet.gameObject.SetActive(false);
    }

    public void SetBulletPool(MisilBulletGenerator bulletPool)
    {
        _bulletPool = bulletPool;
    }

    IEnumerator DestroyBullet(MisilHero bullet)
    {
        yield return new WaitForSeconds(3f);
        _bulletPool.ReturnBulletToPool(bullet);
    }

    public void OnCollisionEnter(Collision collision)
    {
        _bulletPool.ReturnBulletToPool(this);
    }
}
