using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public float height;
    private Vector3 startPos;
    private int direction = 1;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {

        float newY = transform.position.y + (direction * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);


        if (Mathf.Abs(transform.position.y - startPos.y) >= height)
        {
            direction *= -1;
        }
    }
}