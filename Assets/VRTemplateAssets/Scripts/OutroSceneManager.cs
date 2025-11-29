using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class OutroSceneManager : MonoBehaviour
{
    public CanvasGroup professorPanel;
    public CanvasGroup mummyPanel;
    public CanvasGroup outroPanel;

    public AudioSource footstepsAudio;
    public AudioSource jumpscareAudio;

    public float professorTextDuration = 2f;
    public float mummyFadeTime = 0.2f;
    public float outroDelay = 2f;

    void Start()
    {
        professorPanel.alpha = 1;
        mummyPanel.alpha = 0;
        outroPanel.alpha = 0;

        StartCoroutine(PlaySequence());
    }

    IEnumerator PlaySequence()
    {
        yield return new WaitForSeconds(professorTextDuration);

        footstepsAudio.Play();

        yield return new WaitForSeconds(footstepsAudio.clip.length);

        jumpscareAudio.Play();

        float t = 0f;
        while (t < mummyFadeTime)
        {
            t += Time.deltaTime;
            mummyPanel.alpha = Mathf.Lerp(0, 1, t / mummyFadeTime);
            yield return null;
        }

        yield return new WaitForSeconds(outroDelay);

        t = 0;
        while (t < 1f)
        {
            t += Time.deltaTime;
            outroPanel.alpha = Mathf.Lerp(0, 1, t);
            yield return null;
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("Intro");
    }
}
