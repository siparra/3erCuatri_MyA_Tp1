﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : MonoBehaviour, IEnemy, IObservable {

    private int _life;
    private float _speed;
    
    //Movement Strategy
    private IMovement _currentMovement;
    private IMovement strategyMovement_Normal;
    private IMovement strategyMovement_Sinuous;
    private IMovement strategyMovement_Target;

    private IEnemyBullet _bullet;
    private EnemyBulletGenerator _bulletPool;
    private float canShoot;
    public Transform gun;
    public GameManager observer;

    private Vector3 _startPosition = new Vector3(0,12.6f,0);

    private EnemyAGenerator _enemyPool;

    private List<IObserver> _allObservers = new List<IObserver>();
    public GameObject explosion;
    public List<GameObject> posiblesPowerUPS;
    public List<float> weights;


    // Use this for initialization
    void Awake () {
        observer = FindObjectOfType<GameManager>();
        canShoot = 1f;
        _bulletPool = GetComponent<EnemyBulletGenerator>();
        _allObservers.Add(observer);
    }
	
	// Update is called once per frame
	void Update () {
        Mover();
        if (canShoot < 0)
        {
            Shoot();
            canShoot = 1f;
        }
       canShoot -= Time.deltaTime;
        
	}

    public void Shoot()
    { 
       _bulletPool.GetBullet(gun, 2);   //1 = Normal Bulltet Movement (CAMBIAR!)
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
        strategyMovement_Sinuous = new SinuousAdvance(_speed,10f, this.transform);
        //Strategy3
        _currentMovement = strategyMovement_Sinuous;
        
    }

    public static void InitializeEnemy(EnemyA enemy)
    {
        enemy.gameObject.SetActive(true);
        enemy.Initialize();
    }
    public static void DisposeEnemy(EnemyA enemy)
    {
        enemy.Dispose();
        enemy.gameObject.SetActive(false);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        NotifyObservers("UpdateScore");
        Instantiate(RouletteWheelSelection.GetRandomByWeight(posiblesPowerUPS, weights), this.transform.position, this.transform.rotation);
        Instantiate(explosion, this.transform.position, this.transform.rotation);
        _enemyPool.ReturnEnemyToPool(this);
    }

    public void SetEnemyPool(EnemyAGenerator pEnemyPool)
    {
        _enemyPool = pEnemyPool;
    }

    public void SetStartPosition(Vector3 initialPosition)
    {
        _startPosition = initialPosition;
    }

    public void Subscribe(IObserver observer)
    {
        if (!_allObservers.Contains(observer))
            _allObservers.Add(observer);
    }

    public void Unsubscribe(IObserver observer)
    {
        if (_allObservers.Contains(observer))
            _allObservers.Remove(observer);
    }

    public void NotifyObservers(string action)
    {
        foreach (var observer in _allObservers)
        {
            observer.OnNotify(action);
        }
    }
}
