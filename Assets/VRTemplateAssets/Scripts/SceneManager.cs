using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Unity.Android.Gradle.Manifest;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup outroPanel;
    [SerializeField] private float fadeDuration = 3f;

    [SerializeField] private CanvasGroup mummyCanvas;

    [SerializeField] private Button restartButton;


    void Start()
    {
      StartCoroutine(StartOutro(mummyCanvas, outroPanel));
      mummyCanvas.enabled = false;
   
    }

    IEnumerator StartOutro(CanvasGroup mummy,CanvasGroup outro)
    {
        yield return new WaitForSeconds(2); 
        yield return StartCoroutine(Fade(outro, 3f)); 
        mummyCanvas.enabled = true;
        yield return new WaitForSeconds(3f);
        mummyCanvas.enabled = true;
        outroPanel.enabled = true;

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

    void OllisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "RestartButton")
        {
            RestartScene();
        }
        
    }
    void RestartScene()
    {
       UnityEngine.SceneManagement.SceneManager.LoadScene("IntroScene");
    }
}
