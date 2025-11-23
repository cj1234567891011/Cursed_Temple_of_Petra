using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup outroPanel;
    [SerializeField] private float fadeDuration = 3f;


    void Start()
    {
      StartCoroutine(StartOutro(outroPanel));
   
    }

    IEnumerator StartOutro(CanvasGroup group)
    {
        yield return new WaitForSeconds(2); 
        yield return StartCoroutine(Fade(group, 3f)); 
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
