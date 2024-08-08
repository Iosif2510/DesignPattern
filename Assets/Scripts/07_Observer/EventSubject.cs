using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSubject : MonoBehaviour
{
    public event System.Action<int> OnEvent = null;

    public UnityEvent onUnityEventCall = new();

    private float timeSpent = 0;
    private int calledTime = 0;
    
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeSpent += Time.deltaTime;
        if (timeSpent >= 3f)
        {
            timeSpent -= 3f;
            OnEvent?.Invoke(calledTime++);
            onUnityEventCall.Invoke();
        }
}
}
