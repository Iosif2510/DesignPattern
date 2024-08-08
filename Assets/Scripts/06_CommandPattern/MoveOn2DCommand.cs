using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOn2DCommand : ICommand
{
    private Transform moveTransform;
    private Vector3 moveDirection;

    public MoveOn2DCommand(Transform moveTransform, float x, float z)
    {
        this.moveTransform = moveTransform;
        this.moveDirection = new Vector3(x, 0, z);
    }
    
    public MoveOn2DCommand(Transform moveTransform, Vector2 moveDirection)
    {
        this.moveTransform = moveTransform;
        this.moveDirection = new Vector3(moveDirection.x, 0, moveDirection.y);
    }
    
    public void Execute()
    {
        moveTransform.Translate(moveDirection);
    }

    public void Undo()
    {
        moveTransform.Translate(-moveDirection);
    }
}
