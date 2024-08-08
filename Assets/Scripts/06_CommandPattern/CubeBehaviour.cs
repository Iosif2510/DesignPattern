using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            CommandInvoker.Instance.ExecuteCommand(new MoveOn2DCommand(transform, 0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            CommandInvoker.Instance.ExecuteCommand(new MoveOn2DCommand(transform, -1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            CommandInvoker.Instance.ExecuteCommand(new MoveOn2DCommand(transform, 0, -1));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            CommandInvoker.Instance.ExecuteCommand(new MoveOn2DCommand(transform, 1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            CommandInvoker.Instance.UndoCommand();
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            CommandInvoker.Instance.RedoCommand();
        }
    }
}
