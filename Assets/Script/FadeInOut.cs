using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float timeToFade = 1f;

    void Start()
    {
        // Ensure the canvas group starts fully transparent or opaque
        canvasGroup.alpha = 1; // Start fully opaque (black)
        StartCoroutine(FadeCanvas(0)); // Start by fading out
    }

    public void FadeIn()
    {
        StartCoroutine(FadeCanvas(1));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCanvas(0));
    }

    IEnumerator FadeCanvas(float targetAlpha)
    {
        float startAlpha = canvasGroup.alpha;
        float elapsedTime = 0f;

        while (elapsedTime < timeToFade)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / timeToFade);
            yield return null;
        }

        canvasGroup.alpha = targetAlpha;
    }

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(FadeOutAndChangeScene(sceneName));
    }

    IEnumerator FadeOutAndChangeScene(string sceneName)
    {
        yield return StartCoroutine(FadeCanvas(1)); // Fade to black
        SceneManager.LoadScene(sceneName);
        yield return StartCoroutine(FadeCanvas(0)); // Fade in from black
    }
}
