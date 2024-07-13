using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralComponent : MonoBehaviour
{
    public void PrintMethod(string message = "Called from GeneralComponent")
    {
        Debug.Log(message);
    }
}
