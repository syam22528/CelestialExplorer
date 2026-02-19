using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;
using TMPro;

public class GestureLocomotion : MonoBehaviour
{
    public Rigidbody player; // Player's Rigidbody
    public float speed;      // Speed of movement
    private bool isFlying = false; // Tracks whether flying is active
    public Transform playerHead; // Reference to the player's head (e.g., VR camera)
    public float maxSpeed = 20f; // Maximum speed limit
    public float minSpeed = 3f;  // Minimum speed limit
    public float speedStep = 1f; // Step for increasing/decreasing speed

    public TextMeshProUGUI speedLabel; // For TextMeshPro Label

    void Start()
    {
        // Ensure the Rigidbody is correctly assigned
        if (player == null)
        {
            player = GetComponent<Rigidbody>();
        }

        // Ensure the player's head is correctly assigned
        if (playerHead == null)
        {
            Debug.LogError("PlayerHead reference is missing. Please assign the VR camera or head transform.");
        }
    }

    void Update()
    {
        if (isFlying && playerHead != null)
        {
            // Get the forward direction of the player's head (ignoring the Y-axis for flat movement)
            Vector3 lookDirection = playerHead.forward;

            // Move the player in the look direction
            player.position += lookDirection.normalized * speed * Time.deltaTime;
        }
    }

    // Function to activate flying
    public void ActivateFlying()
    {
        isFlying = true;
    }

    // Function to deactivate flying
    public void DeactivateFlying()
    {
        isFlying = false;
    }

    public void IncreaseSpeed()
    {
        if (speed < maxSpeed)
        {
            speed += speedStep;
            Debug.Log("Speed increased to: " + speed);
            UpdateSpeedLabel();
        }
        else
        {
            Debug.Log("Maximum speed reached!");
        }
    }

    // Function to decrease the speed
    public void DecreaseSpeed()
    {
        if (speed > minSpeed)
        {
            speed -= speedStep;
            Debug.Log("Speed decreased to: " + speed);
            UpdateSpeedLabel();
        }
        else
        {
            Debug.Log("Minimum speed reached!");
        }
    }
    private void UpdateSpeedLabel()
    {
        if (speedLabel != null)
        {
            speedLabel.text = "Speed: " + speed.ToString("F1"); // Format with 1 decimal place
        }
        else
        {
            Debug.LogError("SpeedLabel is not assigned!");
        }
    }
}
