using UnityEngine;

public class BridgeTrigger : MonoBehaviour
{
    public GameObject bridge; // Köprü nesnesini buraya atayacağız

    void Start()
    {
        bridge.SetActive(false); // Başlangıçta köprüyü gizle
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pushable")) // Kutunun tag'ı "PushableBox" olmalı
        {
            bridge.SetActive(true); // Köprüyü aç
            Debug.Log("Bridge Activated!");
        }
    }
}
