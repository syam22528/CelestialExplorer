using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonGravity : MonoBehaviour
{
    private Vector3 originalGravity;

    void OnEnable()
    {
        // Save the original gravity
        originalGravity = Physics.gravity;

        // Set Moon gravity
        Physics.gravity = new Vector3(0, -1.62f, 0);
    }

    void OnDisable()
    {
        // Restore the original gravity
        Physics.gravity = originalGravity;
    }
}
