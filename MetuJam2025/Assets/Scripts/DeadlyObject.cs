using UnityEngine;
using UnityEngine.SceneManagement; // Sahneyi yeniden başlatmak için gerekli

public class DeadlyObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Eğer çarpan nesne oyuncu ise
        {

            RestartGame();
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Aktif sahneyi yeniden yükle
    }
}
