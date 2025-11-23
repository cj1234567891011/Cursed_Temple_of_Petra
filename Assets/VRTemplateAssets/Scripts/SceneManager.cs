using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject introUIPanel;
    
    public GameObject fullScreenBlackPanel;

    
    void Start()
    {
        StartCoroutine(IntroSequence());

        SceneManager.LoadNextSceneAsync("Escape1");
    }

    private void IntroSequence()
    {
        
        yield return StartCoroutine(Fade(fullScreenBlackPanel.GetComponent<CanvasGroup>(), 0f));
    
        yield return StartCoroutine(Fade(introUIPanel, 2f)); 
        yield return new WaitForSeconds(7f); 
        yield return StartCoroutine(Fade(introUIPanel, 1f)); 

        SceneManager.LoadNextSceneAsync("Escape1");
        
    }

    IEnumerator Fade(CanvasGroup group, float targetAlpha)
    {
        float startAlpha = group.alpha;
        float time = 0;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
           
           //review this line, might cause bugs
            group.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
           
            yield return null; 
        }
        group.alpha = targetAlpha;
    }

    
}
