using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleInstance<T> : MonoBehaviour where T : SingleInstance<T>
{
    private static T instance = null;

    public T Instance
    {
        get
        {
            if (instance == null) InitSingleton();
            return instance;
        }
    }


    private static void InitSingleton()
    {
        if (instance != null) return;
        instance = FindObjectOfType<T>();
        if (instance == null)
        {
            var managerObject = GameObject.Find("SingleInstance");
            if (managerObject == null)
            {
                managerObject = new GameObject();
                managerObject.name = "SingleInstance";
            }
            instance = managerObject.AddComponent<T>();
            DontDestroyOnLoad(managerObject);
        }
    }

    protected virtual void Awake()
    {
        if (instance == (T)this) return;
        if (instance == null)
        {
            instance = (T)this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
