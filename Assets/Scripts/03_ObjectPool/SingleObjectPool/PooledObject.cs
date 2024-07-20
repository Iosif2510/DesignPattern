using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    private static ObjectPool objectPool;

    public static ObjectPool Pool { get => objectPool; set => objectPool = value; }

    public void Initialize()
    {
        transform.localPosition = new Vector3(0, 0, 0);
    }

    public static PooledObject CreatePoolObject()
    {
        return objectPool.GetObject();
    }
    
    public static T CreatePoolObject<T>() where T : MonoBehaviour
    {
        return objectPool.GetObject().GetComponent<T>();
    }

    public void ReturnToPool()
    {
        objectPool.ReturnObject(this);
    }
    
    
}
