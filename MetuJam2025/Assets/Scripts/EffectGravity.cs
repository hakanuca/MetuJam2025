using UnityEngine;

public class EffectGravity : MonoBehaviour
{
    private bool isYFrozen = false; // Initially, movement is free
    private Rigidbody2D playerRb;

    void Start()
    {
        // Reset constraints to ensure the character is not affected initially
        playerRb = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Rigidbody2D>();
        if (playerRb != null)
        {
            playerRb.constraints = RigidbodyConstraints2D.FreezeRotation; // Sadece Z ekseni rotasyonu donduruluyor
        }

        FreezeYPosition(isYFrozen); // Affect other objects initially
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) // Toggle on pressing "G" key
        {
            isYFrozen = !isYFrozen;
            Debug.Log("Toggling Y freeze: " + isYFrozen);
            FreezeYPosition(isYFrozen);
        }
    }

    void FreezeYPosition(bool freeze)
    {
        // Find all Rigidbody2D objects in the scene
        Rigidbody2D[] rigidbodies = FindObjectsByType<Rigidbody2D>(FindObjectsSortMode.None);

        for (int i = 0; i < rigidbodies.Length; i++)
        {
            // Skip if the object has the "Player" tag (except the character)
            if (rigidbodies[i].CompareTag("Player"))
                continue;

            if (freeze)
            {
                rigidbodies[i].constraints = RigidbodyConstraints2D.FreezePositionY; // Freeze movement on Y axis
                Debug.Log("Freezing Y position for: " + rigidbodies[i].gameObject.name);
            }
            else
            {
                rigidbodies[i].constraints = RigidbodyConstraints2D.None; // Release movement
                Debug.Log("Releasing Y position for: " + rigidbodies[i].gameObject.name);
            }
        }

        // Handle the player's Rigidbody2D separately
        if (playerRb != null)
        {
            if (freeze)
            {
                playerRb.constraints = RigidbodyConstraints2D.FreezeRotation; // Sadece Z ekseni rotasyonu donduruluyor
            }
            else
            {
                playerRb.constraints = RigidbodyConstraints2D.FreezeRotation; // Z ekseni rotasyonu dondurulmuş kalıyor
            }
        }
    }
}
