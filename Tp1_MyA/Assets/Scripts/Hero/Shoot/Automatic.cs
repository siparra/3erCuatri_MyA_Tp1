using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automatic : IShootStrategy
{
    //TODO: preguntar si Strategy se puede hacer con clases abstractas en vez de interfaces; para poder instanciar y startiar corrutinas.
    private bool _canShot;
    private float _fireRate;
    private GameObject _bullet;
    private Transform _mainGun;
    private float _contador;
    public NormalBulletGenerator _bulletPool;

    public Automatic(bool pcanShot, float pfireRate, GameObject pBullet, Transform pMainGun, NormalBulletGenerator pBulletPool)
    {
        _canShot = pcanShot;
        _fireRate = pfireRate;
        _bullet = pBullet;
        _mainGun = pMainGun;
        _bulletPool = pBulletPool;
    }


    public override void Shoot()
    {
        _contador += Time.deltaTime;

        if (_canShot)
        {
            //Instantiate(_bullet, _mainGun.position, Quaternion.identity);
            _bulletPool.GetBullet(_mainGun);
            _canShot = false;
        }
            if(_contador > _fireRate)
            {
                _canShot = true;
                _contador = 0f;
            }
    }

}
