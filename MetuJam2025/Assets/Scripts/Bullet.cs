using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BulletPool bulletPool;

    public void InitializeBullet(BulletPool pool)
    {
        bulletPool = pool;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // You can add collision logic here
        bulletPool.ReturnBullet(gameObject); // Return the bullet to the pool
    }

    void OnBecameInvisible()
    {
        bulletPool.ReturnBullet(gameObject); // Return bullet when it goes off-screen
    }
}