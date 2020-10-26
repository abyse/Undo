using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCommand : ICommand
{
    private Rotator _rotator;
    private Vector3 _eulerAngles;

    private GameObject _targetGO;

    public RotateCommand(Rotator rotator, Vector3 eulerAngles)
    {
        _rotator = rotator;
        _eulerAngles = eulerAngles;

        _targetGO = rotator.Current;
    }

    public void Execute()
    {
        var go = _rotator.Current;

        _rotator.Current = _targetGO;
        _rotator.Rotate(_eulerAngles);
        _rotator.Current = go;
    }

    public void Undo()
    {
        var go = _rotator.Current;

        _rotator.Current = _targetGO;
        _rotator.Rotate(-_eulerAngles);
        _rotator.Current = go;
    }
}
