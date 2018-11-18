using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAGenerator : MonoBehaviour
{
    public int amount;
    public EnemyA prefab;
    private Pool<EnemyA> _enemyPool;

    private static EnemyAGenerator _instance;
    public static EnemyAGenerator Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this;
        _enemyPool = new Pool<EnemyA>(amount, EnemyFactory, EnemyA.InitializeEnemy, EnemyA.DisposeEnemy, true);
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _enemyPool.GetObjectFromPool();
        }
    }

    //Factory de Enemies
    private EnemyA EnemyFactory()
    {
        return Instantiate<EnemyA>(prefab);
    }

    //El spawner es el unico que conoce al pool de EnemyA, asi que nos llega un objeto por parametro y a ese lo mandamos por parametro para que el pool se encargue de desactivarlo de la lista para vovler a usarlo.
    public void ReturnEnemyToPool(EnemyA enemy)
    {
        _enemyPool.DisablePoolObject(enemy);
    }
}
