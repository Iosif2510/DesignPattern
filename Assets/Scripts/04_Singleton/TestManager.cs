using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : GenericSingleton<TestManager>
{
    public void Test()
    {
        Debug.Log("TestManager");
    }
}
