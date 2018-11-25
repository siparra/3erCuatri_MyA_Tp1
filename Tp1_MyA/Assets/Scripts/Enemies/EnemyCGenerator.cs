﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCGenerator : MonoBehaviour {
    public int amount;
    public EnemyC prefab;
    private Pool<EnemyC> _enemyPool;

    private static EnemyCGenerator _instance;
    public static EnemyCGenerator Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this;
        _enemyPool = new Pool<EnemyC>(amount, EnemyFactory, EnemyC.InitializeEnemy, EnemyC.DisposeEnemy, true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var enemy = _enemyPool.GetObjectFromPool();
            enemy.SetEnemyPool(this);
            enemy.SetStartPosition(this.transform.position);
        }
    }

    //Factory de Enemies
    private EnemyC EnemyFactory()
    {
        return Instantiate<EnemyC>(prefab, this.transform.position, this.transform.rotation);
    }

    //El spawner es el unico que conoce al pool de EnemyA, asi que nos llega un objeto por parametro y a ese lo mandamos por parametro para que el pool se encargue de desactivarlo de la lista para vovler a usarlo.
    public void ReturnEnemyToPool(EnemyC enemy)
    {
        _enemyPool.DisablePoolObject(enemy);
    }
}
