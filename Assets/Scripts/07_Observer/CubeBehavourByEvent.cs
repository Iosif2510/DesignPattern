using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehavourByEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DebugMessage()
    {
        Debug.Log(gameObject.name);
    }

    public void Move()
    {
        transform.Translate(1, 0, 0);
    }
}
