using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        
        if (TestManager.Instance == null) return;
        TestManager.Instance.Test();
        SoundManager.Instance.Test();
    }
}
