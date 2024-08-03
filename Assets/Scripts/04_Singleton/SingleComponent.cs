using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleComponent : SingleInstance<SingleComponent>
{
    public void PrintTestSingle() => Instance.PrintTest();
    
    private void PrintTest()
    {
        Debug.Log("Single Component!");
    }
}
