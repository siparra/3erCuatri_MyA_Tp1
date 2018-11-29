using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBGenerator : MonoBehaviour {
    public int amount;
    public EnemyB prefab;
    private Pool<EnemyB> _enemyPool;
    public List<Transform> generatorPoints;

    private static EnemyBGenerator _instance;
    public static EnemyBGenerator Instance { get { return _instance; } }

    public float timer;
    private float initialTime;

    private void Awake()
    {
        _instance = this;
        _enemyPool = new Pool<EnemyB>(amount, EnemyFactory, EnemyB.InitializeEnemy, EnemyB.DisposeEnemy, true);
        initialTime = timer;
        
    }

    void Update()
    {
        if (timer < 0)
        {
            var random = Random.Range(0, 2);
            var enemy = _enemyPool.GetObjectFromPool();
            enemy.SetEnemyPool(this);
            enemy.SetStartPosition(generatorPoints[random].position);
            timer = initialTime;
        }
        timer -= Time.deltaTime;
    }

    //Factory de Enemies
    private EnemyB EnemyFactory()
    {
        var random = Random.Range(0, 2);
        return Instantiate<EnemyB>(prefab, generatorPoints[random].position, generatorPoints[random].rotation);
    }

    //El spawner es el unico que conoce al pool de EnemyA, asi que nos llega un objeto por parametro y a ese lo mandamos por parametro para que el pool se encargue de desactivarlo de la lista para vovler a usarlo.
    public void ReturnEnemyToPool(EnemyB enemy)
    {
        _enemyPool.DisablePoolObject(enemy);
    }
}
