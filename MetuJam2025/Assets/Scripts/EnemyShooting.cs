using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float shootInterval = 1f; // Time between shots
    public float bulletSpeed = 5f; // Speed of the bullet
    private BulletPool bulletPool;

    void Start()
    {
        bulletPool = FindObjectOfType<BulletPool>(); // Find the BulletPool in the scene
        InvokeRepeating("Shoot", 0f, shootInterval); // Start shooting at regular intervals
    }

    void Shoot()
    {
        GameObject bullet = bulletPool.GetBullet();
        bullet.transform.position = transform.position; // Set bullet's position to enemy's position
        bullet.GetComponent<Rigidbody2D>().linearVelocity = transform.up * bulletSpeed; // Move the bullet
        bullet.GetComponent<Bullet>().InitializeBullet(bulletPool); // Set up the bullet with the pool for later return
    }
}
