using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventObserver : MonoBehaviour
{
    [SerializeField] private EventSubject subject;
    [SerializeField] private int id;
    
    // Start is called before the first frame update
    private void Awake()
    {
        subject.OnEvent += PrintDebug;
        subject.onUnityEventCall.AddListener(() => PrintDebug(0));
    }

    // Update is called once per frame
    private void PrintDebug(int inputCount)
    {
        Debug.Log($"EventObserver {id} called with input {inputCount}");
    }

    private void OnDestroy()
    {
        subject.OnEvent -= PrintDebug;
        subject.onUnityEventCall.RemoveListener(() => PrintDebug(0));
    }
}
