using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : MonoBehaviour, IEnemy {

    private int _life;
    private float _speed;
    public IBullet _bullet;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void Mover()
    {
        throw new System.NotImplementedException();
    }

    public void SetBulletType(IBullet bullet)
    {
        throw new System.NotImplementedException();
    }

    public void SetLife(int life)
    {
        throw new System.NotImplementedException();
    }

    public void SetSpeed(float speed)
    {
        throw new System.NotImplementedException();
    }

    //Para el POOL
     public void Dispose()
    {
        //throw new System.NotImplementedException();
    }

    public void Initialize()
    {
        //throw new System.NotImplementedException();
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
