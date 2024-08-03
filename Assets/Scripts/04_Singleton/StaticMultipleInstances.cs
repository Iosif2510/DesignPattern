using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMultipleInstances : MonoBehaviour
{
    private static List<StaticMultipleInstances> instance = new ();

    public static List<StaticMultipleInstances> Instance => instance;


    protected void Awake()
    {
        if (!instance.Contains(this))
        {
            instance.Add(this);
        }
    }
}
