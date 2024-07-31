using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenericSingleton<T> : MonoBehaviour where T : GenericSingleton<T>
{
    private static T instance = null;

    public static T Instance
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
            var managerObject = GameObject.Find("@Managers");
            if (managerObject == null)
            {
                managerObject = new GameObject();
                managerObject.name = "@Managers";
            }
            instance = managerObject.AddComponent<T>();
            DontDestroyOnLoad(managerObject);
        }
    }

    protected virtual void Awake()
    {
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
