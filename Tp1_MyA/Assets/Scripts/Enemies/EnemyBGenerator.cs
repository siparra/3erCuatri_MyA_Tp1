using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBGenerator : MonoBehaviour {
    public int amount;
    public EnemyB prefab;
    private Pool<EnemyB> _enemyPool;

    private static EnemyBGenerator _instance;
    public static EnemyBGenerator Instance { get { return _instance; } }
    public float timer;

    private void Awake()
    {
        _instance = this;
        _enemyPool = new Pool<EnemyB>(amount, EnemyFactory, EnemyB.InitializeEnemy, EnemyB.DisposeEnemy, true);
        timer = 5f;
    }

    void Update()
    {
        if (timer < 0)
        {
            var enemy = _enemyPool.GetObjectFromPool();
            enemy.SetEnemyPool(this);
            enemy.SetStartPosition(this.transform.position);
            timer = 5f;
        }
        timer -= Time.deltaTime;
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
