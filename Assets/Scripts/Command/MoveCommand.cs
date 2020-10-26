using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    private Mover _mover;
    private Vector3 _translation;

    private GameObject _targetGO;

    public MoveCommand(Mover mover, Vector3 translation)
    {
        _mover = mover;
        _translation = translation;

        _targetGO = mover.Current;
    }

    public void Execute()
    {
        var go = _mover.Current;

        _mover.Current = _targetGO;
        _mover.Move(_translation);
        _mover.Current = go;
    }

    public void Undo()
    {
        var go = _mover.Current;

        _mover.Current = _targetGO;
        _mover.Move(-_translation);
        _mover.Current = go;
    }
}
