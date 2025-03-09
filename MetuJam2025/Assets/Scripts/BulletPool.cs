using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab; // Bullet prefab
    public int poolSize = 10; // Size of the pool
    private Queue<GameObject> bulletPool; // Queue to hold bullets

    void Start()
    {
        bulletPool = new Queue<GameObject>();
        // Initialize pool with inactive bullets
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    public GameObject GetBullet()
    {
        if (bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }
        else
        {
            // Optional: if the pool is empty, create a new bullet
            GameObject newBullet = Instantiate(bulletPrefab);
            return newBullet;
        }
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
}
