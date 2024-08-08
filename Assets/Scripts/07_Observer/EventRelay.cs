using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRelay : MonoBehaviour
{
    [SerializeField] private List<EventListener> listeners;

    private void Awake()
    {
        foreach (var listener in listeners)
        {
            listener.Register();
        }
    }
}
