using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleObjectPool : MonoBehaviour
{

    [SerializeField] private List<PooledObjectInMultiple> prefabList;
    [SerializeField] private List<int> initialPoolSize;
    
    private Dictionary<PooledObjectInMultiple, Queue<PooledObjectInMultiple>> objectPoolDictionary;

    // Start is called before the first frame update
    void Awake()
    {
        PooledObjectInMultiple.objectPool = this;
        objectPoolDictionary = new(prefabList.Count);
        foreach (var prefab in prefabList)
        {
            
            var initialSize = initialPoolSize[prefabList.IndexOf(prefab)];
            var objectPool = new Queue<PooledObjectInMultiple>(initialSize);
            objectPoolDictionary.Add(prefab, objectPool);
            for (var i = 0; i < initialSize; i++)
            {
                PooledObjectInMultiple pooledObject = InstantiatePooledObject(prefab);
                pooledObject.OriginalPrefab = prefab;
                pooledObject.ReturnToPool();
            }
        }
    }

    public PooledObjectInMultiple GetObject(PooledObjectInMultiple prefab)
    {
        if (!objectPoolDictionary.ContainsKey(prefab))
        {
            Debug.LogError("Prefab not found in the pool");
            return null;
        }
        
        var objectPool = objectPoolDictionary[prefab];
        var pooledObject = objectPool.Count == 0 ? InstantiatePooledObject(prefab) : objectPool.Dequeue();
        pooledObject.gameObject.SetActive(true);
        pooledObject.Initialize();
        return pooledObject;
    }
    
    public void ReturnObject(PooledObjectInMultiple pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
        objectPoolDictionary[pooledObject.OriginalPrefab].Enqueue(pooledObject);
    }
    
    private PooledObjectInMultiple InstantiatePooledObject(PooledObjectInMultiple prefab)
    {
        var instance = Instantiate(prefab, transform);
        instance.OriginalPrefab = prefab;
        return instance;
    }
}
