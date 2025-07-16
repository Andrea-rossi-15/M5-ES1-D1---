using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1f;

    private Coroutine currentFade;
    private bool isFaded = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentFade != null)
            {
                StopCoroutine(currentFade);
            }


            if (isFaded)
                currentFade = StartCoroutine(FadeIn());
            else
                currentFade = StartCoroutine(FadeOut());

            isFaded = !isFaded;
        }
    }

    IEnumerator FadeOut()
    {
        float elapsed = 0f;
        Color c = fadeImage.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsed / fadeDuration);
            fadeImage.color = c;
            yield return null;
        }

        c.a = 1f;
        fadeImage.color = c;
    }

    IEnumerator FadeIn()
    {
        float elapsed = 0f;
        Color c = fadeImage.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            c.a = Mathf.Clamp01(1f - (elapsed / fadeDuration));
            fadeImage.color = c;
            yield return null;
        }

        c.a = 0f;
        fadeImage.color = c;
    }
}