using UnityEngine;

public class MoonRevolve : MonoBehaviour
{
    [Header("Orbit Settings")]
    public Transform earth; // The Earth object (center of orbit)
    public float orbitSpeed = 10f; // Speed of revolution in degrees per second
    public float orbitRadius = 2f; // Distance from the Earth

    [Header("Rotation Settings")]
    public bool rotateMoon = true; // Should the moon rotate on its own axis?
    public float moonRotationSpeed = 50f; // Speed of the moon's self-rotation

    private Vector3 orbitAxis = Vector3.up; // Axis of revolution (can be changed for tilted orbits)
    private Vector3 startPosition; // Original position relative to Earth

    void Start()
    {
        // Ensure the moon starts at the correct distance from Earth
        if (earth != null)
        {
            startPosition = (transform.position - earth.position).normalized * orbitRadius;
            transform.position = earth.position + startPosition;
        }
    }

    void Update()
    {
        if (earth != null)
        {
            // Perform revolution around Earth
            transform.RotateAround(earth.position, orbitAxis, orbitSpeed * Time.deltaTime);

            // Maintain correct orbit radius (useful in case of floating-point drift)
            Vector3 offset = transform.position - earth.position;
            transform.position = earth.position + offset.normalized * orbitRadius;

            // Optional: Rotate the moon on its own axis
            if (rotateMoon)
            {
                transform.Rotate(Vector3.up, moonRotationSpeed * Time.deltaTime, Space.Self);
            }
        }
    }
}
