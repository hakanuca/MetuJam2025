using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomImageSpawner : MonoBehaviour
{
    public List<Sprite> imagesToSpawn; // Spawn edilecek resimlerin listesi
    public Transform spawnArea; // Spawn alanının merkezi
    public Vector2 spawnRange; // Spawn alanının genişliği (X, Y yönünde)
    public float spawnInterval = 2f; // Spawn süresi
    public GameObject imagePrefab; // UI Image prefabı
    public Transform canvasTransform; // UI öğelerinin ekleneceği canvas

    void Start()
    {
        StartCoroutine(SpawnImages());
    }

    IEnumerator SpawnImages()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnRandomImage();
        }
    }

    void SpawnRandomImage()
    {
        if (imagesToSpawn.Count == 0 || imagePrefab == null || canvasTransform == null) return;

        // Rastgele resim seç
        Sprite randomImage = imagesToSpawn[Random.Range(0, imagesToSpawn.Count)];

        // Rastgele konum belirle
        Vector2 randomPosition = new Vector2(
            spawnArea.position.x + Random.Range(-spawnRange.x / 2, spawnRange.x / 2),
            spawnArea.position.y + Random.Range(-spawnRange.y / 2, spawnRange.y / 2)
        );

        // UI Image oluştur
        GameObject newImage = Instantiate(imagePrefab, canvasTransform);
        newImage.GetComponent<Image>().sprite = randomImage;
        newImage.GetComponent<RectTransform>().anchoredPosition = randomPosition;
    }
}