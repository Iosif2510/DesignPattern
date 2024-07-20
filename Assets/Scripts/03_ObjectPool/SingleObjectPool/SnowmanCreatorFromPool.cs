using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanCreatorFromPool : MonoBehaviour
{
    [SerializeField] private ObjectPool objectPool;
    
    private void Start()
    {
        StartCoroutine(CreateSnowman());
    }
    
    private IEnumerator CreateSnowman()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            PooledObject snowman = objectPool.GetObject();
        }
    }
}
