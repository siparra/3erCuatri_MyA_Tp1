using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triple : IShootStrategy
{

    private bool _canShot;
    private float _fireRate;
    private GameObject _bullet;
    private Transform _mainGun;
    private Transform _sideGunL;
    private Transform _sideGunR;
    private float _contador;

    public NormalBulletGenerator _bulletPool;

    public Triple(bool pcanShot, float pfireRate, GameObject pBullet, Transform pMainGun, Transform pSideGunL, Transform pSideGunR, NormalBulletGenerator pBulletPool)
    {
        _canShot = pcanShot;
        _fireRate = pfireRate;
        _bullet = pBullet;
        _mainGun = pMainGun;
        _sideGunL = pSideGunL;
        _sideGunR = pSideGunR;
        _bulletPool = pBulletPool;
    }


    public override void Shoot()
    {
        _contador += Time.deltaTime;

        if (_canShot)
        {
            _bulletPool.GetBullet(_mainGun);
            _bulletPool.GetBullet(_sideGunL);
            _bulletPool.GetBullet(_sideGunR);
            _canShot = false;
        }
        if (_contador > _fireRate)
        {
            _canShot = true;
            _contador = 0f;
        }
    }
}
