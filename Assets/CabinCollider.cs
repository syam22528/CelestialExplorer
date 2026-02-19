using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinCollider : MonoBehaviour
{
[SerializeField] private Collider cabinCollider; // Still visible in Inspector
[SerializeField] private Transform cameraTransform; // Still visible in Inspector
    void Update()
    {
        // Get the closest point on the cabin's collider to the camera's position
        Vector3 closestPoint = cabinCollider.ClosestPoint(cameraTransform.position);
        
        // If the camera's position is outside, snap it to the closest point
        if (!cabinCollider.bounds.Contains(cameraTransform.position))
        {
            cameraTransform.position = closestPoint;
        }
    }
}
