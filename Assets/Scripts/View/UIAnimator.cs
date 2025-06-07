using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIAnimator : MonoBehaviour
{
    public Canvas targetCanvas;
    public RawImage backgroundImage; // Image � ������, ������� ��������� ���� Canvas
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
            Debug.LogWarning("Background Image �� ��������!");
            yield break;
        }

        // ��������, ��� canvas �������
        targetCanvas.enabled = true;

        // ��������� ���������
        backgroundImage.canvasRenderer.SetAlpha(0f);
        backgroundImage.CrossFadeAlpha(1f, fadeDuration, false);

        yield return new WaitForSeconds(fadeDuration);
    }
}
