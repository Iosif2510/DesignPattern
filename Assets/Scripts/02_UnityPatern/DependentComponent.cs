using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GeneralComponent))]
public class DependentComponent : MonoBehaviour
{
    private GeneralComponent dependingComponent;
    private void Awake()
    {
        dependingComponent = GetComponent<GeneralComponent>();
    }

    private void Start()
    {
        dependingComponent.PrintMethod("Called from DependentComponent");
    }
    
}
