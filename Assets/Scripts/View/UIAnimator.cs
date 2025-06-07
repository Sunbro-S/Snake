using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIAnimator : MonoBehaviour
{
    public Canvas targetCanvas;
    public RawImage backgroundImage; // Image с альфой, который покрывает весь Canvas
    public float fadeDuration = 1f;

    public void Awake()
    {
        gameObject.SetActive(false);
    }
    public void Show()
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        if (backgroundImage == null)
        {
            Debug.LogWarning("Background Image не назначен!");
            yield break;
        }

        // Убедимся, что canvas активен
        targetCanvas.enabled = true;

        // Начальное состояние
        backgroundImage.canvasRenderer.SetAlpha(0f);
        backgroundImage.CrossFadeAlpha(1f, fadeDuration, false);

        yield return new WaitForSeconds(fadeDuration);
    }
}
