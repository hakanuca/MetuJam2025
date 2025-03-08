using UnityEngine;
using UnityEngine.SceneManagement; // Sahneyi yeniden başlatmak için gerekli

public class DeadlyObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Eğer çarpan nesne oyuncu ise
        {

            RestartGame();
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Aktif sahneyi yeniden yükle
    }
}
