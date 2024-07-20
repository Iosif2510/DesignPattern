using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public abstract class PooledObjectInMultiple : MonoBehaviour
{
    public static MultipleObjectPool objectPool;
    private PooledObjectInMultiple originalPrefab;
    
    public PooledObjectInMultiple OriginalPrefab
    {
        get => originalPrefab;
        set => originalPrefab = value;
    }
    
    public UnityEvent onReturnToPool = new UnityEvent();
    public UnityEvent onObjectSpawn = new UnityEvent();

    public virtual void Initialize()
    {
        onObjectSpawn.Invoke();
    }


    private void OnSceneUnloaded(Scene scene)
    {
        objectPool = null;
    }

    public static PooledObjectInMultiple CreatePoolObject(PooledObjectInMultiple originalPrefab)
    {
        var pooledObject = objectPool.GetObject(originalPrefab);
        return pooledObject;
    }
    
    public static T CreatePoolObject<T>(PooledObjectInMultiple originalPrefab) where T : MonoBehaviour
    {
        return CreatePoolObject(originalPrefab).GetComponent<T>();
    }

    public void ReturnToPool()
    {
        objectPool.ReturnObject(this);
        onReturnToPool.Invoke();
    }

}
