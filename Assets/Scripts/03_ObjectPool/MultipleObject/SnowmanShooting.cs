using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SnowmanShooting : MonoBehaviour
{
    [SerializeField] private PooledSnowball snowballPrefab;
    [SerializeField] private float movingSpeed = 2.0f;
    
    [SerializeField] private float shootingInterval = 1.0f;
    private float shootingTimer;

    private void Awake()
    {
        shootingTimer = shootingInterval;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(movingSpeed * Time.deltaTime * Vector3.forward);
        if (shootingTimer >= shootingInterval)
        {
            ShootSnowball();
            shootingTimer -= shootingInterval;
        }
        shootingTimer += Time.deltaTime;
    }

    private void ShootSnowball()
    {
        var snowball = PooledObjectInMultiple.CreatePoolObject(snowballPrefab);
        snowball.onObjectSpawn.AddListener(() => { snowball.GetComponent<Rigidbody>().MovePosition(transform.position); });
    }
}
