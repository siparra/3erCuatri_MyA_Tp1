using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : MonoBehaviour, IEnemy {

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

    // Use this for initialization
    void Awake () {
        canShoot = 1f;
        _bulletPool = GetComponent<EnemyBulletGenerator>();
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
        //throw new System.NotImplementedException();
    }

    public void Initialize()
    {
        _life = 100;
        _speed = 0.01f;
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

}
