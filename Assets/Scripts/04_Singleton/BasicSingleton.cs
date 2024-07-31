using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSingleton : MonoBehaviour
{
    private static BasicSingleton instance = null;

    public static BasicSingleton Instance
    {
        get
        {
            if (instance == null) Init();
            return instance;
        }
    }

    private static void Init()
    {
        if (instance != null) return;
        instance = FindObjectOfType<BasicSingleton>();
        if (instance == null)
        {
            var managerObject = new GameObject();
            managerObject.name = "@Managers";
            instance = managerObject.AddComponent<BasicSingleton>();
            DontDestroyOnLoad(managerObject);
        }
    }
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Test()
    {
        Debug.Log("Test() called!");
    }
}
