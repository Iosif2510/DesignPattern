using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private PooledObject prefabToPool;
    [SerializeField] private int initialPoolSize = 10;

    public Queue<PooledObject> objectPool;

    private void Awake()
    {
        objectPool = new Queue<PooledObject>();

        for (int i = 0; i < initialPoolSize; i++)
        {
            PooledObject pooledObject = Instantiate(prefabToPool, transform);
            PooledObject.Pool = this;
            pooledObject.ReturnToPool();
        }
    }
    
    public PooledObject GetObject()
    {
        if (objectPool.Count == 0)
        {
            PooledObject pooledObject = Instantiate(prefabToPool, transform);
            PooledObject.Pool = this;
            return pooledObject;
        }

        PooledObject pooledObjectFromPool = objectPool.Dequeue();
        pooledObjectFromPool.gameObject.SetActive(true);
        pooledObjectFromPool.Initialize();
        return pooledObjectFromPool;
    }
    
    public void ReturnObject(PooledObject pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
        objectPool.Enqueue(pooledObject);
    }
}
