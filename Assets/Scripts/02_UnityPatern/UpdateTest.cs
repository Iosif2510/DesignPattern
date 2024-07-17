using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTest : MonoBehaviour
{

    // Update is called once per frame
    private void Update()
    {
        Debug.Log($"Update: {Time.deltaTime}s");
        Debug.Log($"Fixed Delta Time: {Time.fixedDeltaTime}s");
    }

    private void LateUpdate()
    {
        Debug.Log($"LateUpdate: {Time.deltaTime}s");
    }

    private void FixedUpdate()
    {
        Debug.Log($"FixedUpdate: {Time.deltaTime}s");
    }
}
