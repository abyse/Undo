using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    [SerializeField]
    private Rotator _rotator;

    [SerializeField]
    private Mover _mover;

    private Invoker _invoker; 

    #region MonoBehaviour

    private void Start()
    {
        _invoker = new Invoker();
    }

    #endregion

    #region Methods

    public void Rotate()
    {
        var command = new RotateCommand(_rotator, new Vector3(0, 45, 25));
        _invoker.SetCommand(command);
        _invoker.Invoke();
    }

    public void Move()
    {
        var command = new MoveCommand(_mover, new Vector3(0, 1, 0));
        _invoker.SetCommand(command);
        _invoker.Invoke();
    }

    public void Undo()
    {
        _invoker.Undo();
    }

    public void Redo()
    {
        _invoker.Redo();
    }

    #endregion
}
