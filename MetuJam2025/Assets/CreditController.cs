using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreditController : MonoBehaviour
{
    public RectTransform creditsText; // Assign the Text RectTransform here
    public CanvasGroup canvasGroup; // Assign the CanvasGroup of the credits UI
    public float scrollSpeed = 50f; // Speed of scrolling
    public float fadeDuration = 2f; // Time to fade out

    private float startY;
    private float endY;
    private bool hasStartedFade = false;

    void Start()
    {
        startY = creditsText.anchoredPosition.y;
        endY = Screen.height + creditsText.rect.height;

        // Start fade-out after a delay
        StartCoroutine(FadeOutAfterDelay(2f)); 
    }

    void Update()
    {
        creditsText.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;
        
        // Restart when it moves off screen
        if (creditsText.anchoredPosition.y >= endY)
        {
            creditsText.anchoredPosition = new Vector2(creditsText.anchoredPosition.x, startY);
        }
    }

    IEnumerator FadeOutAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        float elapsedTime = 0f;
        float startAlpha = canvasGroup.alpha;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, elapsedTime / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}