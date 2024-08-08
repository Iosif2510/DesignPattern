using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Observer/EventRelayObject", fileName = "New EventRelayObject")]
public class EventRelayObject : ScriptableObject
{
    private EventListener listener;
    
    public void RegisterListener(EventListener listener)
    {
        this.listener = listener;
    }
    
    public void UnRegisterListener()
    {
        this.listener = null;
    }

    public void OnEventRaised()
    {
        if (listener != null)
        {
            listener.onEventRaised.Invoke();
        }
    }
}
