using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAGenerator : MonoBehaviour
{
    public int amount;
    public EnemyA prefab;
    private Pool<EnemyA> _enemyPool;
    public List<Transform> generatorPoints;

    private static EnemyAGenerator _instance;
    public static EnemyAGenerator Instance { get { return _instance; } }

    //Instanciador
    public float timer;
    private float initialTime;

    private void Awake()
    {
        _instance = this;
        _enemyPool = new Pool<EnemyA>(amount, EnemyFactory, EnemyA.InitializeEnemy, EnemyA.DisposeEnemy, true);
        initialTime = timer;
    }
	
	void Update () {
        if (timer < 0) {
            var random = Random.Range(0, 2);
            var enemy =_enemyPool.GetObjectFromPool();
            enemy.SetEnemyPool(this);
            enemy.SetStartPosition(generatorPoints[random].position);
            timer = initialTime;
        }
        timer -= Time.deltaTime;
    }

    //Factory de Enemies
    private EnemyA EnemyFactory()
    {
        var random = Random.Range(0, 2);
        return Instantiate<EnemyA>(prefab, generatorPoints[random].position, generatorPoints[random].rotation);
    }

    //El spawner es el unico que conoce al pool de EnemyA, asi que nos llega un objeto por parametro y a ese lo mandamos por parametro para que el pool se encargue de desactivarlo de la lista para vovler a usarlo.
    public void ReturnEnemyToPool(EnemyA enemy)
    {
        _enemyPool.DisablePoolObject(enemy);
    }
}
