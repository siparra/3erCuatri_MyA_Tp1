using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : MonoBehaviour, IEnemy {

    private int _life;
    private float _speed;
    public IBullet _bullet;

    //Movement Strategy
    private IMovement _currentMovement;
    private IMovement strategyMovement_Normal;
    private IMovement strategyMovement_Sinuous;
    private IMovement strategyMovement_Target;

    // Use this for initialization
    void Awake () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Mover();
	}

    public void Shoot()
    {
        throw new System.NotImplementedException();
    }

    public void Mover()
    {
        if (_currentMovement != null)
        {
            _currentMovement.Advance();
        }
    }

    public IEnemy SetBulletType(IBullet bullet)
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
        //bullet

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
