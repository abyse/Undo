using System;
using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    public event Action<GameObject> GOSelected;

    #region MonoBehaviour

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            CheckClick(Input.mousePosition);

    }

    #endregion

    private void CheckClick(Vector3 position)
    {
        var ray = _camera.ScreenPointToRay(position);
        var intersected = Physics.Raycast(ray, out RaycastHit hit);
        if (intersected)
            GOSelected?.Invoke(hit.transform.gameObject);
    }

}
