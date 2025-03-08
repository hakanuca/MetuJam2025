using UnityEngine;

public class MoveCollider : MonoBehaviour
{
    public float speed = 5f;      // Speed of the movement
    public float distance = 3f;   // Maximum distance to move up and down
    public bool startUpwards = true;  // If true, starts going upwards, otherwise downwards

    private Vector3 startPosition; // Initial position of the object
    private float time;

    void Start()
    {
        // Store the starting position of the object
        startPosition = transform.position;

        // Adjust initial time based on the desired starting direction
        time = startUpwards ? 0 : Mathf.PI;  // Start upwards (0) or downwards (PI)
    }

    void Update()
    {
        // Move the object up and down over time
        time += Time.deltaTime * speed;
        float newY = Mathf.Sin(time) * distance; // Sinusoidal motion for smooth back and forth

        // Apply the new Y position to the object
        transform.position = new Vector3(startPosition.x, startPosition.y + newY, startPosition.z);
    }
}