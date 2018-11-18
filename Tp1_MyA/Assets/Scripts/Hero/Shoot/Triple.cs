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

    public Triple(bool pcanShot, float pfireRate, GameObject pBullet, Transform pMainGun, Transform pSideGunL, Transform pSideGunR)
    {
        _canShot = pcanShot;
        _fireRate = pfireRate;
        _bullet = pBullet;
        _mainGun = pMainGun;
        _sideGunL = pSideGunL;
        _sideGunR = pSideGunR;
    }


    public override void Shoot()
    {
        _contador += Time.deltaTime;

        if (_canShot)
        {
            Instantiate(_bullet, _mainGun.position, Quaternion.identity);
            Instantiate(_bullet, _sideGunL.position, Quaternion.identity);
            Instantiate(_bullet, _sideGunR.position, Quaternion.identity);
            _canShot = false;
        }
        if (_contador > _fireRate)
        {
            _canShot = true;
            _contador = 0f;
        }
    }
}
