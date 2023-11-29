using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageFade : MonoBehaviour
{
    public Image img;
    public float fadeDuration = 1.0f; // You can adjust this value

    public void OnEnable()
    {
        StartCoroutine(FadeImage(false, fadeDuration));
    }

    public void OnButtonClick()
    {
        StartCoroutine(FadeImage(true, fadeDuration));
    }

    public void fadeIn()
    {
        StartCoroutine(DarkFadeImage(false, fadeDuration));
    }

    IEnumerator FadeImage(bool fadeAway, float duration)
    {
        float targetAlpha = fadeAway ? 0 : 1;
        float startAlpha = img.color.a;

        float startTime = Time.time;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime = Time.time - startTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            img.color = new Color(1, 1, 1, Mathf.Lerp(startAlpha, targetAlpha, t));
            yield return null;
        }

        if (fadeAway)
        {
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator DarkFadeImage(bool fadeAway, float duration)
    {
        float targetAlpha = fadeAway ? 0 : 1;
        float startAlpha = img.color.a;

        float startTime = Time.time;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime = Time.time - startTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            img.color = new Color(0, 0, 0, Mathf.Lerp(startAlpha, targetAlpha, t));
            yield return null;
        }

        if (fadeAway)
        {
            this.gameObject.SetActive(false);
        }
    }
}
