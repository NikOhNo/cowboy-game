using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.InputSystem;

public class MouseFacer2D : MonoBehaviour
{
    private Transform pivotPoint;

    private void Awake()
    {
        pivotPoint = transform;
    }

    void Update()
    {
        FaceMouse();
    }

    //-- HELPERS
    private void FaceMouse()
    {
        Vector2 mousePos = Mouse.current.position.value;

        var mousePositionZ = Camera.main.farClipPlane;
        var mouseScreenPos = new Vector3(mousePos.x, mousePos.y, mousePositionZ);
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

        Vector3 targetDirection = mouseWorldPos - pivotPoint.position;

        float rotationZ = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        pivotPoint.rotation = Quaternion.Euler(0f, 0f, rotationZ + 270);
    }
}
