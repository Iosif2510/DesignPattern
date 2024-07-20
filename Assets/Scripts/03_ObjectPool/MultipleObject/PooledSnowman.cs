using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledSnowman : PooledObjectInMultiple
{
    private Rigidbody body = null;
    
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    public override void Initialize()
    {
        base.Initialize();
        transform.localPosition = new Vector3(0, 0, 0);
    }
}
