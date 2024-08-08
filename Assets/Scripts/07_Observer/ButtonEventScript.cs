using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEventScript : MonoBehaviour
{
    public EventRelayObject eventRelayObject;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(eventRelayObject.OnEventRaised);
    }
}
