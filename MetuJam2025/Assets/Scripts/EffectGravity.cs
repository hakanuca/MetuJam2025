using UnityEngine;

public class EffectGravity : MonoBehaviour
{
    private Rigidbody2D[] rigidbodies;
    private bool gravityEnabled = true;

    void Start()
    {

        rigidbodies = FindObjectsByType<Rigidbody2D>(FindObjectsSortMode.None);

        SetGravity(true);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {
            gravityEnabled = !gravityEnabled;
            SetGravity(gravityEnabled);
        }
    }

    public void SetGravity(bool enableGravity)
    {
        foreach (var rb in rigidbodies)
        {
            rb.gravityScale = enableGravity ? 1 : 0;
        }


    }
}