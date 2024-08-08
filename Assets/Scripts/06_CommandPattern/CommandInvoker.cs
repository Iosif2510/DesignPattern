using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : GenericSingleton<CommandInvoker>
{
    private LinkedList<ICommand> commandStack = new();
    private LinkedList<ICommand> redoStack = new();
    private int maxStackSize = 20;

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        if (commandStack.Count >= maxStackSize)
        {
            commandStack.RemoveFirst();
        }
        commandStack.AddLast(command);
        redoStack.Clear();
    }
    
    public void UndoCommand()
    {
        if (commandStack.Count > 0)
        {
            ICommand command = commandStack.Last.Value;
            commandStack.RemoveLast();
            command.Undo();
            if (redoStack.Count >= maxStackSize)
            {
                redoStack.RemoveFirst();
            }
            redoStack.AddLast(command);
        }
    }
    
    public void RedoCommand()
    {
        if (redoStack.Count > 0)
        {
            ICommand command = redoStack.Last.Value;
            redoStack.RemoveLast();
            command.Execute();
            if (commandStack.Count >= maxStackSize)
            {
                commandStack.RemoveFirst();
            }
            commandStack.AddLast(command);
        }
    }
}
