using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private Selector _selector;

    public GameObject Current { get; set; }

    #region MonoBehaviour

    private void OnEnable()
    {
        _selector.GOSelected += OnGOSelected;
    }

    private void OnDisable()
    {
        _selector.GOSelected -= OnGOSelected;
    }

    #endregion

    #region Methods

    public void Rotate(Vector3 eulerAngles)
    {
        if (Current == null)
            return;

        Current.transform.Rotate(eulerAngles);
    }

    #endregion

    private void OnGOSelected(GameObject go)
    {
        Current = go;
    }
}
