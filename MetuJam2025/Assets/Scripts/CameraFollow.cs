using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
    public Transform target; 
    public float smoothSpeed = 0.125f; 
    public Vector3 offset = new Vector3(0, 2, -10); 
    private bool stopCamera = false; 
    private Vector3 lastValidPosition; 

    void Start()
    {
        lastValidPosition = transform.position; 
    }

    void LateUpdate()
    {
        if (target == null) return;

        if (!stopCamera)
        {
            Vector3 desiredPosition = target.position + offset;

         
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = smoothedPosition;

         
            lastValidPosition = transform.position;
        }
        else
        {
           
            transform.position = lastValidPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")) 
        {
            stopCamera = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")) 
        {
            stopCamera = false; 
        }
    }
}