using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSceneManagerController : MonoBehaviour
{
    [SerializeField] private CanvasGroup introPanel;
    [SerializeField] private float fadeDuration = 3f;

    public Image fadeImage;

    void Start()
    {
        StartCoroutine(StartIntro(introPanel));
        introPanel.enabled = false;
    }

    IEnumerator StartIntro(CanvasGroup introPanel)
    {
        Color startColor = fadeImage.color;
        startColor.a = 1f;
        fadeImage.color = startColor;

        yield return new WaitForSeconds(2);
        yield return StartCoroutine(Fade(introPanel, 3f));

        introPanel.enabled = true;
        yield return new WaitForSeconds(8f);

        SceneManager.LoadScene("Escape1");
    }

    IEnumerator Fade(CanvasGroup group, float targetAlpha)
    {
        float startAlpha = group.alpha;
        float time = 0;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            group.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            yield return null;
        }

        group.alpha = targetAlpha;
    }
}
