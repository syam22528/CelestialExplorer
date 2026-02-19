using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class JoystickLocomotion : MonoBehaviour
{
    public Rigidbody player;
    public float speed;

    void Start()
    {
        // Ensure the Rigidbody is correctly assigned
        if (player == null)
        {
            player = GetComponent<Rigidbody>();
        }
    }

    void Update()
    {

        // Get the joystick input from the left thumbstick
        var joystick = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick, OVRInput.Controller.RTouch);

        // Move the player based on joystick input
        player.position += (transform.right * joystick.x + transform.forward * joystick.y) * speed * Time.deltaTime;

        // Reset the Y position to the original fixed value
        player.position = new Vector3(player.position.x, player.position.y, player.position.z);
    }
}
