using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBehaviour : MonoBehaviour
{
    [SerializeField] private bool debug = false;
    [SerializeField] private SingleComponent singleComponent;
    
    // Start is called before the first frame update
    void Awake()
    {
        singleComponent.PrintTestSingle();
        if (!debug)
        {
            TestManager.Instance.Test();
            SoundManager.Instance.Test();
        }
        else
        {
            // 대체 로직
        }
    }
}
