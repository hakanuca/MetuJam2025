using UnityEngine;

public class TimePuse : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isPaused = !isPaused;
            
            // Find all objects with the tag "time"
            GameObject[] timeTaggedObjects = GameObject.FindGameObjectsWithTag("time");

            foreach (GameObject obj in timeTaggedObjects)
            {
                // Pause/Resume animation if Animator exists
                Animator animator = obj.GetComponent<Animator>();
                if (animator != null)
                    animator.speed = isPaused ? 0 : 1;

                // Stop/resume physics simulation while keeping movement data
                Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
                if (rb != null)
                    rb.simulated = !isPaused;
            }
        }
    }
}