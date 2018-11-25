using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBGenerator : MonoBehaviour {
    public int amount;
    public EnemyB prefab;
    private Pool<EnemyB> _enemyPool;

    private static EnemyBGenerator _instance;
    public static EnemyBGenerator Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this;
        _enemyPool = new Pool<EnemyB>(amount, EnemyFactory, EnemyB.InitializeEnemy, EnemyB.DisposeEnemy, true);
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
    private EnemyB EnemyFactory()
    {
        return Instantiate<EnemyB>(prefab, this.transform.position, this.transform.rotation);
    }

    //El spawner es el unico que conoce al pool de EnemyA, asi que nos llega un objeto por parametro y a ese lo mandamos por parametro para que el pool se encargue de desactivarlo de la lista para vovler a usarlo.
    public void ReturnEnemyToPool(EnemyB enemy)
    {
        _enemyPool.DisablePoolObject(enemy);
    }
}
