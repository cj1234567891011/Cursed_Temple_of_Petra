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

    public SceneManager sceneManager;
    
    void Start()
    {
        StartCoroutine("IntroSequence()");

    }

    IEnumerable IntroSequence()
    {
        
        yield return StartCoroutine(Fade(fullScreenBlackPanel.GetComponent<CanvasGroup>(), 0f));
    
        yield return StartCoroutine(Fade(introUIPanel, 2f)); 
        yield return new WaitForSeconds(7f); 
        yield return StartCoroutine(Fade(introUIPanel, 1f)); 

        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Escape1");
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
