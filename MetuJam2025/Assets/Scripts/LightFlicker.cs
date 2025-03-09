using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class LightFlicker : MonoBehaviour
{
    private Light2D lightSource; // 2D ışık bileşeni
    public float minFlickerDelay = 0.1f; // Minimum yanıp sönme süresi
    public float maxFlickerDelay = 1.5f; // Maksimum yanıp sönme süresi
    public float flickerAmount = 0.5f; // Ne kadar azalıp artacağı

    void Start()
    {
        lightSource = GetComponent<Light2D>(); // Light2D bileşenini al
        StartCoroutine(FlickerEffect()); // Yanıp sönme efekti başlat
    }

    IEnumerator FlickerEffect()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minFlickerDelay, maxFlickerDelay));

            // Işığın şeffaflık efektini değiştir
            Color lightColor = lightSource.color;
            float alpha = Random.Range(0.3f, 1f); // 0.3 ile 1 arasında ışığın parlaklığı değişir
            lightSource.color = new Color(lightColor.r, lightColor.g, lightColor.b, alpha);
        }
    }
}
