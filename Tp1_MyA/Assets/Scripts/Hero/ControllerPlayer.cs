using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : IController {

    ModelPlayer _model;
    ViewPlayer _view;
    Player _player;
    private float _speed = 5f;

    public ControllerPlayer(ModelPlayer pModel, ViewPlayer pView, Player pPlayer)
    {
        _model = pModel;
        _view = pView;
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


        if(_model.typeOfShoot == TypeOfShoot.TRIPLE)
        {
            _view.ActivateGuns(_player.sideGunL.gameObject, _player.sideGunR.gameObject);
            
        }else if(_model.typeOfShoot == TypeOfShoot.AUTOMATIC)
        {
            _view.DeActivateGuns(_player.sideGunL.gameObject, _player.sideGunR.gameObject);
            _view.DeActivateMisilGuns(_player.misilGunL.gameObject, _player.misilGunR.gameObject);
        }else if(_model.typeOfShoot == TypeOfShoot.MISIL)
        {
            _view.ActivateGuns(_player.sideGunL.gameObject, _player.sideGunR.gameObject);
            _view.ActivateMisilGuns(_player.misilGunL.gameObject, _player.misilGunR.gameObject);
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
