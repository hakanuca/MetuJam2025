using UnityEngine;

public class Door : MonoBehaviour
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

                // Freeze/unfreeze movement if Rigidbody2D exists
                Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
                if (rb != null)
                    rb.bodyType = isPaused ? RigidbodyType2D.Static : RigidbodyType2D.Dynamic;

                // Disable/Enable Collider2D if exists
                Collider2D col = obj.GetComponent<Collider2D>();
                if (col != null)
                    col.enabled = !isPaused;
            }
        }
    }
}