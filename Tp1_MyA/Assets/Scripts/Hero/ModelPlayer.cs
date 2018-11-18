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

    public ModelPlayer(Transform pHeroTransform)
    {
        _heroTransform = pHeroTransform;
        _player = _heroTransform.GetComponent<Player>();
    }

    public void OnMove(Vector3 newPos)
    {
        _heroTransform.position += newPos * Time.deltaTime;
    }

    public void OnShoot()
    {
        Shoot(typeOfShoot);
    }

}
    public enum TypeOfShoot
    {
        AUTOMATIC,
        TRIPLE
    }
