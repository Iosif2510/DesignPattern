using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanSpawner : MonoBehaviour
{
    [SerializeField] private PooledSnowman snowmanPrefab;
    
    private void Start()
    {
        StartCoroutine(CreateSnowman());
    }
    
    private IEnumerator CreateSnowman()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            PooledObjectInMultiple.CreatePoolObject(snowmanPrefab);
        }
    }
}
