using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleSceneSingleton : MonoBehaviour
{
    private static SingleSceneSingleton instance = null;

    public static SingleSceneSingleton Instance
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
        instance = FindObjectOfType<SingleSceneSingleton>();
        if (instance == null)
        {
            var managerObject = new GameObject();
            managerObject.name = "@Managers";
            instance = managerObject.AddComponent<SingleSceneSingleton>();
        }
    }
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            SceneManager.sceneUnloaded += OnSceneUnload;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneUnload(Scene scene)
    {
        instance = null;
    }

    public void Test()
    {
        Debug.Log("Test() called!");
    }
}
