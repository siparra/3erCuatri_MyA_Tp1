using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T>
{
    private List<PoolObject<T>> _poolList;
    public delegate T CallbackFactory();

    private int _count; //Stock para el pool del objetos
    private bool _isDinamic = false; //Si el pool es dinamico cuando se acaben los objetos se creara uno nuevo.
    private PoolObject<T>.PoolCallback _init; //funcion para inicializar el obj
    private PoolObject<T>.PoolCallback _finalize; //funcion para finalizar el objeto
    private CallbackFactory _factoryMethod; //metodo de la Factory para crear los objetos

    public Pool(int initialStock, CallbackFactory factoryMethod, PoolObject<T>.PoolCallback initialize, PoolObject<T>.PoolCallback finalize, bool isDinamic)
    {
        //Creamos una lista de objetos Pooleables
        _poolList = new List<PoolObject<T>>();

        //Guardamos las referencias para cuando los necesitemos.
        _factoryMethod = factoryMethod;
        _isDinamic = isDinamic;
        _count = initialStock;
        _init = initialize;
        _finalize = finalize;

        //Generamos el stock inicial.
        for (int i = 0; i < _count; i++)
        {
            _poolList.Add(new PoolObject<T>(_factoryMethod(), _init, _finalize));

        }
    }

    //Funcion para retornar un objeto del pool
    public T GetObjectFromPool()
    {
        for (int i = 0; i < _poolList.Count - 1; i++)
        {
            if (!_poolList[i].isActive)
            {
                _poolList[i].isActive = true;
                return _poolList[i].GetObj;
            }
        }
        //Si tenemos todos los objecto en uso,vamos a preguntar si es dinamico para poder crear mas
        if (_isDinamic)
        {
            PoolObject<T> po = new PoolObject<T>(_factoryMethod(), _init, _finalize);
            po.isActive = true;
            _poolList.Add(po);
            _count++;
            return po.GetObj;
        }
        return default(T);
    }

    //Funcion para desactivar un objeto.
    public void DisablePoolObject(T obj)
    {
        foreach (PoolObject<T> poolObj in _poolList)
        {
            if (poolObj.GetObj.Equals(obj))
            {
                poolObj.isActive = false;
                return;
            }
        }
    }
}
