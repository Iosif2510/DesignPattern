using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledSnowball : PooledObjectInMultiple
{
    private Rigidbody body = null;
    
    // Start is called before the first frame update
    public override void Initialize()
    {
        base.Initialize();
        if (body == null) body = GetComponent<Rigidbody>();
        body.velocity = Vector3.zero;
        body.AddForce(new Vector3(5, 2, 0), ForceMode.Impulse);
    }
}
