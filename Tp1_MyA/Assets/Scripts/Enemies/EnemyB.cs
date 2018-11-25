﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : MonoBehaviour, IEnemy {
    private int _life;
    private float _speed;

    //Movement Strategy
    private IMovement _currentMovement;
    private IMovement strategyMovement_Normal;
    private IMovement strategyMovement_Sinuous;
    private IMovement strategyMovement_Target;


    //Shoot
    public Transform pivot;
    public Transform gun; //BulletGenerator
    private IEnemyBullet _bullet;
    private EnemyBulletGenerator _bulletPool;
    private float canShoot;
    
    private Vector3 _startPosition = new Vector3(0, 12.6f, 0);

    private EnemyBGenerator _enemyPool;

    // Use this for initialization
    void Awake()
    {
        canShoot = 0.3f;
        _bulletPool = GetComponent<EnemyBulletGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        if (canShoot < 0)
        {
            Shoot();
            canShoot = 0.3f;
        }
        canShoot -= Time.deltaTime;

    }

    public void Shoot()
    {




        _bulletPool.GetBullet(gun, 1);   //1 = Normal Bulltet Movement (CAMBIAR!)
    }

    public void Mover()
    {
        if (_currentMovement != null)
        {
            _currentMovement.Advance();
        }
    }

    public IEnemy SetBulletType(IEnemyBullet bullet)
    {
        _bullet = bullet;
        return this;
    }

    public IEnemy SetLife(int life)
    {
        _life = life;
        return this;
    }

    public IEnemy SetSpeed(float speed)
    {
        _speed = speed;
        return this;
    }
    //Para el POOL
    public void Dispose()
    {
        _life = 100;
        this.transform.position = _startPosition;
    }

    public void Initialize()
    {

        _life = 100;
        //_speed = 0.01f; //CAMBIAR a 0.01f cuando es Movimiento Sinuoso
        _speed = 1f;

        //Movement
        strategyMovement_Normal = new NormalAdvance(_speed, this.transform);
        strategyMovement_Sinuous = new SinuousAdvance(_speed, 10f, this.transform);
        //Strategy3
        _currentMovement = strategyMovement_Normal;

    }

    public static void InitializeEnemy(EnemyB enemy)
    {
        enemy.gameObject.SetActive(true);
        enemy.Initialize();
    }
    public static void DisposeEnemy(EnemyB enemy)
    {
        enemy.Dispose();
        enemy.gameObject.SetActive(false);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        _enemyPool.ReturnEnemyToPool(this);
    }

    public void SetEnemyPool(EnemyBGenerator pEnemyPool)
    {
        _enemyPool = pEnemyPool;
    }

    public void SetStartPosition(Vector3 initialPosition)
    {
        _startPosition = initialPosition;
    }
}