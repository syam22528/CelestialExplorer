using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShipMovement : MonoBehaviour
{
    // This field should be visible in the Inspector to allow you to assign the camera transform
    public Transform cameraTransform; // Drag the VR camera (CenterEyeAnchor) here in the Inspector

    public Vector3 insideShipPosition = new Vector3(-0.364f, 2.844f, 5.935f); // Position for entering the ship
    public float moveDistance = 8f; // Distance to move on the x-axis when exiting the ship
    public float moveSpeed = 5f; // Speed of movement when transitioning

    private Vector3 initialPosition;

    private void Start()
    {
        // Store the initial position of the camera for reference
        initialPosition = cameraTransform.position;
    }

    // Method to move inside the ship to a specific position
    public void MoveInsideShip()
    {
        StopAllCoroutines();
        StartCoroutine(MoveToPosition(insideShipPosition));
    }

    // Method to move outside the ship by shifting the x-axis
    public void MoveOutsideShip()
    {
        StopAllCoroutines();
        Vector3 targetPosition = new Vector3(initialPosition.x - moveDistance, initialPosition.y, initialPosition.z);
        StartCoroutine(MoveToPosition(targetPosition));
    }

    // Coroutine to smoothly move the camera to a target position
    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        while (Vector3.Distance(cameraTransform.position, targetPosition) > 0.01f)
        {
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetPosition, Time.deltaTime * moveSpeed);
            yield return null;
        }
        cameraTransform.position = targetPosition;
    }
}
