﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAGenerator : MonoBehaviour
{
    public int amount;
    public EnemyA prefab;
    private Pool<EnemyA> _enemyPool;

    private static EnemyAGenerator _instance;
    public static EnemyAGenerator Instance { get { return _instance; } }

    public float timer;

    private void Awake()
    {
        _instance = this;
        _enemyPool = new Pool<EnemyA>(amount, EnemyFactory, EnemyA.InitializeEnemy, EnemyA.DisposeEnemy, true);

        timer = 1.5f;
    }
	
	void Update () {
        if (timer < 0) { 
            var enemy =_enemyPool.GetObjectFromPool();
            enemy.SetEnemyPool(this);
            enemy.SetStartPosition(this.transform.position);
            timer = 1.5f;
        }
        timer -= Time.deltaTime;
    }

    //Factory de Enemies
    private EnemyA EnemyFactory()
    {
        return Instantiate<EnemyA>(prefab, this.transform.position, this.transform.rotation);
    }

    //El spawner es el unico que conoce al pool de EnemyA, asi que nos llega un objeto por parametro y a ese lo mandamos por parametro para que el pool se encargue de desactivarlo de la lista para vovler a usarlo.
    public void ReturnEnemyToPool(EnemyA enemy)
    {
        _enemyPool.DisablePoolObject(enemy);
    }
}
