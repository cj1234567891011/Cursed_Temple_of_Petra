using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class SceneManager : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup introUIPanel;
    
    public CanvasGroup fullScreenBlackPanel;

    
    void Start()
    {
        StartCoroutine(IntroSequence());

        SceneManager.LoadNextSceneAsync("Escape1");
    }

    private void StartCoroutine(IEnumerable enumerable)
    {
        throw new NotImplementedException();
    }

    private static void LoadNextSceneAsync(string v)
    {
        throw new NotImplementedException();
    }

    IEnumerable IntroSequence()
    {
        
        yield return StartCoroutine(Fade(fullScreenBlackPanel.GetComponent<CanvasGroup>(), 0f));
    
        yield return StartCoroutine(Fade(introUIPanel, 2f)); 
        yield return new WaitForSeconds(7f); 
        yield return StartCoroutine(Fade(introUIPanel, 1f)); 

        SceneManager.LoadNext("Escape1");        
    }

    private static void LoadNext(string v)
    {
        throw new NotImplementedException();
    }

    IEnumerator Fade(CanvasGroup group, float targetAlpha)
    {
        float startAlpha = group.alpha;
        float time = 0;
        while (time < 2f)
        {
            time += Time.deltaTime;
           
           //review this line, might cause bugs
            group.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / 2f);
           
            yield return null; 
        }
        group.alpha = targetAlpha;
    }

    
}
