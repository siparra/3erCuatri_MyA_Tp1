using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misil : IShootStrategy
{

    private bool _canShot;
    private float _fireRate;
    private GameObject _bullet;
    private Transform _mainGun;
    private Transform _sideGunL;
    private Transform _sideGunR;
    private Transform _misilGunR;
    private Transform _misilGunL;
    private float _contador;

    public NormalBulletGenerator _bulletPool;
    public MisilBulletGenerator _misilPool;

    public Misil(bool pcanShot, float pfireRate, GameObject pBullet, Transform pMainGun, Transform pSideGunL, Transform pSideGunR, 
        NormalBulletGenerator pBulletPool, Transform pMisilGunL, Transform pMisilGunR, MisilBulletGenerator pMisilPool)
    {
        _canShot = pcanShot;
        _fireRate = pfireRate;
        _bullet = pBullet;
        _mainGun = pMainGun;
        _sideGunL = pSideGunL;
        _sideGunR = pSideGunR;
        _bulletPool = pBulletPool;
        _misilGunL = pMisilGunL;
        _misilGunR = pMisilGunR;
        _misilPool = pMisilPool;
    }


    public override void Shoot()
    {
        _contador += Time.deltaTime;

        if (_canShot)
        {
            _bulletPool.GetBullet(_mainGun);
            _bulletPool.GetBullet(_sideGunL);
            _bulletPool.GetBullet(_sideGunR);
            _misilPool.GetBullet(_misilGunL);
            _misilPool.GetBullet(_misilGunR);
            _canShot = false;
        }
        if (_contador > _fireRate)
        {
            _canShot = true;
            _contador = 0f;
        }
    }
}
