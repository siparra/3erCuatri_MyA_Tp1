﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : IController {

    ModelPlayer _model;
    ViewPlayer _view;
    Player _player;
    private float _speed = 5f;

    private GameObject _bullet;

    public ControllerPlayer(ModelPlayer pModel, ViewPlayer pView, GameObject pBullet, Player pPlayer)
    {
        _model = pModel;
        _view = pView;
        _bullet = pBullet;
        _player = pPlayer;
        _model.Shoot += _player.ShootByType;
    }

    public override void OnUpdate()
    {
        Move();
        Shoot();
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _model.OnMove(new Vector3(1 * _speed, 0, 0));

        }

        if (Input.GetKey(KeyCode.A))
        {
            _model.OnMove(new Vector3(1 * _speed * -1, 0, 0));
        }

        if (Input.GetKey(KeyCode.W))
        {
            _model.OnMove(new Vector3(0, 1 * _speed, 0));
        }

        if (Input.GetKey(KeyCode.S))
        {
            _model.OnMove(new Vector3(0, 1 * _speed * -1, 0));
        }
    }
    public void Shoot()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _model.OnShoot();
        }
    }
}