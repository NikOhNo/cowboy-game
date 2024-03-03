using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTarget : MonoBehaviour
{
    void Update()
    {
        // Get the current mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Set the distance between the camera and the object
        mousePosition.z = 10f; // Assuming the camera is at (0, 0, -10)

        // Convert the screen coordinates to world coordinates
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Set the object's position to the calculated world position
        transform.position = worldPosition;
    }
}
