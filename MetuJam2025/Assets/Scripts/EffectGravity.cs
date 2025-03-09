using UnityEngine;

public class EffectGravity : MonoBehaviour
{
    private bool isYFrozen = false; // Başlangıçta hareket serbest

    void Start()
    {
        // Karakterin başlangıçta etkilenmemesi için constraints'ini sıfırla
        Rigidbody2D playerRb = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Rigidbody2D>();
        if (playerRb != null)
        {
            playerRb.constraints = RigidbodyConstraints2D.None; // Karakter başlangıçta serbest olacak
        }

        FreezeYPosition(isYFrozen); // Diğer nesneleri başlangıçta etkilesin
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) // "G" tuşuna basınca aç/kapat
        {
            isYFrozen = !isYFrozen;
            FreezeYPosition(isYFrozen);
        }
    }

    void FreezeYPosition(bool freeze)
    {
        // Sahnedeki tüm Rigidbody2D nesnelerini bul
        Rigidbody2D[] rigidbodies = FindObjectsByType<Rigidbody2D>(FindObjectsSortMode.None);

        for (int i = 0; i < rigidbodies.Length; i++)
        {
            // Eğer nesne "Player" tag'ine sahipse, işlem yapma (karakter hariç!)
            if (rigidbodies[i].CompareTag("Player"))
                continue;

            if (freeze)
            {
                rigidbodies[i].constraints = RigidbodyConstraints2D.FreezePositionY; // Y ekseninde hareketi dondur
                Debug.Log(rigidbodies[i].gameObject.name + " - Y Position Frozen");
            }
            else
            {
                rigidbodies[i].constraints = RigidbodyConstraints2D.None; // Hareketi serbest bırak
                Debug.Log(rigidbodies[i].gameObject.name + " - Y Position Unfrozen");

                // 🚀 **Küçük bir aşağı itme kuvveti uygula**
                rigidbodies[i].AddForce(new Vector2(0, -2f), ForceMode2D.Impulse);
            }
        }

        Debug.Log("Y Position Freeze: " + (freeze ? "ON" : "OFF"));
    }
}
