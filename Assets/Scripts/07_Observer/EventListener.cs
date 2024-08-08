using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EventListener
{
    public EventRelayObject eventRelayObject;
    public UnityEvent onEventRaised = new();

    public void Register()
    {
        eventRelayObject.RegisterListener(this);
    }
    
}
