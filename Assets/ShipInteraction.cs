using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInteraction : MonoBehaviour
{
    [SerializeField] private Transform cameraRig;        // Reference to the player (camera rig or player GameObject)
    [SerializeField] private Transform entryPoint;       // Reference to the spaceship's entry point
    [SerializeField] private Transform exitPoint;        // Reference to the spaceship's exit point
    [SerializeField] private GameObject canvasPlanePrefab; // Reference to the CanvasPlaneVariant prefab
    [SerializeField] private Transform palmMenuParent;   // Parent transform for the canvas, typically the palm

    private GameObject canvasInstance;                  // Instance of the CanvasPlaneVariant

    public void EnterSpaceship()
    {
        if (cameraRig != null && entryPoint != null)
        {
            Debug.Log("Entering Spaceship...");
            cameraRig.position = entryPoint.position;
            cameraRig.rotation = entryPoint.rotation;
        }
        else
        {
            Debug.LogWarning("Entry point or camera rig not assigned.");
        }
    }

    public void ExitSpaceship()
    {
        if (cameraRig != null && exitPoint != null)
        {
            Debug.Log("Exiting Spaceship...");
            cameraRig.position = exitPoint.position;
            cameraRig.rotation = exitPoint.rotation;
        }
        else
        {
            Debug.LogWarning("Exit point or camera rig not assigned.");
        }
    }

    public void ToggleCanvasPlaneVariant()
    {
        if (canvasInstance == null)
        {
            // Instantiate the prefab and parent it to the palm menu
            canvasInstance = Instantiate(canvasPlanePrefab, palmMenuParent);

            // Set position, rotation, and scale relative to the palm menu
            canvasInstance.transform.localPosition = new Vector3(0f, 0.5f, 0.5f); // Close and slightly above
            canvasInstance.transform.localRotation = Quaternion.Euler(20f, 0f, 0f); // Rotate 20 degrees on X-axis
            canvasInstance.transform.localScale = Vector3.one * 0.01f; // Scale down for visibility

            Debug.Log("CanvasPlaneVariant instantiated and displayed.");
        }
        else
        {
            // Check if the canvas instance is part of the scene and toggle its active state
            bool isActive = canvasInstance.activeSelf;

            if (isActive)
            {
                canvasInstance.SetActive(false);
                Debug.Log("Hiding CanvasPlaneVariant.");
            }
            else
            {
                canvasInstance.SetActive(true);
                Debug.Log("Displaying CanvasPlaneVariant.");
            }
        
        }
    }
}
