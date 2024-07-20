using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnyPooledObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Snowball") || other.CompareTag("Snowman"))
        {
            other.GetComponent<PooledObjectInMultiple>().ReturnToPool();
        }
    }
}
