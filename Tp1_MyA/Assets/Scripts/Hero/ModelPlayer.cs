using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ModelPlayer
{
    public event Action<TypeOfShoot> Shoot = delegate { };

    private Transform _heroTransform;
    private Player _player;
    public TypeOfShoot typeOfShoot;
    private GameObject _shield;

    public ModelPlayer(Transform pHeroTransform, GameObject pShield)
    {
        _heroTransform = pHeroTransform;
        _player = _heroTransform.GetComponent<Player>();
        _shield = pShield;
    }

    public void OnMove(Vector3 newPos)
    {
        _heroTransform.position += newPos * Time.deltaTime;
    }

    public void OnShoot()
    {
        Shoot(typeOfShoot);
    }

    public void PowerUpGun()
    {
        if (typeOfShoot == TypeOfShoot.TRIPLE)
        {
            typeOfShoot = TypeOfShoot.MISIL;
        }
        else if (typeOfShoot == TypeOfShoot.AUTOMATIC)
        {
            typeOfShoot = TypeOfShoot.TRIPLE;
        }
        else if (typeOfShoot == TypeOfShoot.MISIL)
        {
            typeOfShoot = TypeOfShoot.MISIL;
        }
    }

    public void PowerUpShield()
    {
        _shield.SetActive(true);
    }

}
    public enum TypeOfShoot
    {
        AUTOMATIC,
        TRIPLE,
        MISIL
    }
