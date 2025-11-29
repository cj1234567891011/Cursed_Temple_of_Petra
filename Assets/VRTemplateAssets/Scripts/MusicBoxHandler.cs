using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class MusicBoxHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject musicBoxOpenedUI;

    [SerializeField]
    private GameObject musicBoxLockedUI;

    [SerializeField]
    private GameObject musicBoxvideo;

    public KeyHandler hasKey;

    void Start()
    {
        if (musicBoxOpenedUI != null)
            musicBoxOpenedUI.SetActive(false);
        if (musicBoxLockedUI != null)
            musicBoxLockedUI.SetActive(false);

        if (musicBoxvideo != null)
        {
            var audio = musicBoxvideo.GetComponent<AudioSource>();
            if (audio != null) audio.Stop();

            var video = musicBoxvideo.GetComponent<VideoPlayer>();
            if (video != null)
            {
                video.Stop();
                video.playOnAwake = false;
            }
        }
    }

    public void TryOpenMusicBox()
    {
        Debug.Log("[MusicBoxHandler1] TryOpenMusicBox called");

        StopAllCoroutines();
        StartCoroutine(OpenMusicBox());
    }

    private IEnumerator OpenMusicBox()
    {
        Debug.Log("[MusicBoxHandler1] OpenMusicBox: KeyCollected = " + KeyHandler.KeyCollected);

        if (KeyHandler.KeyCollected)
        {
            Debug.Log("[MusicBoxHandler1] Player HAS the key, opening box");

            if (musicBoxOpenedUI != null)
            {
                musicBoxOpenedUI.SetActive(true);
                yield return new WaitForSeconds(5f);
                musicBoxOpenedUI.SetActive(false);
            }

            if (musicBoxvideo != null)
            {
                var audio = musicBoxvideo.GetComponent<AudioSource>();
                if (audio != null)
                {
                    Debug.Log("[MusicBoxHandler1] Playing AudioSource on musicBoxvideo");
                    audio.Play();
                }

                var video = musicBoxvideo.GetComponent<VideoPlayer>();
                if (video != null)
                {
                    Debug.Log("[MusicBoxHandler1] Playing VideoPlayer on musicBoxvideo");
                    video.Play();
                }
            }
            else
            {
                Debug.LogWarning("[MusicBoxHandler1] musicBoxvideo is not assigned");
            }
        }
        else
        {
            Debug.Log("[MusicBoxHandler1] Player does NOT have the key, showing locked UI");

            if (musicBoxLockedUI != null)
            {
                musicBoxLockedUI.SetActive(true);
                yield return new WaitForSeconds(5f);
                musicBoxLockedUI.SetActive(false);
            }
        }
    }
}
