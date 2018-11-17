using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelPlayer
{
    private Transform _heroTransform;
    private Player _player;

    public ModelPlayer(Transform pHeroTransform)
    {
        _heroTransform = pHeroTransform;
        _player = _heroTransform.GetComponent<Player>();
    }

    public void OnMove(Vector3 newPos)
    {
        _heroTransform.position += newPos * Time.deltaTime;
    }

    public void OnShoot(GameObject pBullet)
    {
       
    }
}
