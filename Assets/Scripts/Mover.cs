using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
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

    public void Move(Vector3 translation)
    {
        if (Current == null)
            return;

        Current.transform.Translate(translation);
    }

    #endregion

    private void OnGOSelected(GameObject go)
    {
        Current = go;
    }

}
