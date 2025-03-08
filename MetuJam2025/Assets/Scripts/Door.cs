using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAnimator;
    public Rigidbody2D doorRigidbody;
    public Collider2D doorTrigger;
    
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isPaused = !isPaused;
            
            // Pause/Resume animation
            if (doorAnimator != null)
                doorAnimator.speed = isPaused ? 0 : 1;
            
            // Freeze movement
            if (doorRigidbody != null)
                doorRigidbody.bodyType = isPaused ? RigidbodyType2D.Static : RigidbodyType2D.Dynamic;
            
            // Disable/Enable triggers
            if (doorTrigger != null)
                doorTrigger.enabled = !isPaused;
        }
    }
}