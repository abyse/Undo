using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker
{
    private ICommand _command;

    private Stack<ICommand> _undo = new Stack<ICommand>();

    private Stack<ICommand> _redo = new Stack<ICommand>();

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void Invoke()
    {
        _command.Execute();
        _undo.Push(_command);
    }

    public void Undo()
    {
        if (_undo.Count < 1)
            return;

        var command = _undo.Pop();

        command.Undo();
        _redo.Push(command);
    }

    public void Redo()
    {
        if (_redo.Count < 1)
            return;


        var command = _redo.Pop();

        command.Execute();
        _undo.Push(command);

    }

}
