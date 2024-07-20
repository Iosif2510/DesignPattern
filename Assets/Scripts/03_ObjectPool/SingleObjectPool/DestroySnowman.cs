using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySnowman : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Snowman"))
        {
            other.GetComponent<PooledObject>().ReturnToPool();
        }
    }
}
