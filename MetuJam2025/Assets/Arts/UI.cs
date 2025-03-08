using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MoveAndActivate : MonoBehaviour
{
    public Transform objectToMove; // Hareket ettirilecek obje
    public Vector3 pointA;
    public Vector3 pointB;
    public float moveSpeed = 2f;
    public GameObject objectToActivate; // Aktifleştirilecek obje
    public float fadeDuration = 1f;

    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = objectToActivate.GetComponent<CanvasGroup>();
        objectToActivate.SetActive(false);
        StartCoroutine(StartSequence());
    }

    IEnumerator StartSequence()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(MoveObject());
    }

    IEnumerator MoveObject()
    {
        float elapsedTime = 0f;
        Vector3 startPos = pointA;
        
        while (elapsedTime < 1f)
        {
            objectToMove.position = Vector3.Lerp(startPos, pointB, elapsedTime);
            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null;
        }
        
        objectToMove.position = pointB;
        
        // Hareket tamamlandıktan sonra objeyi aktifleştir ve transparandan görünür hale getir
        objectToActivate.SetActive(true);
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        canvasGroup.alpha = 0f;

        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 1f;
    }
}