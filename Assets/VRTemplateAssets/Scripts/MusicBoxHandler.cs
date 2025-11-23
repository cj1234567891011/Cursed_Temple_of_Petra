using System.Collections;
using UnityEngine;

public class MusicBoxHandler1 : MonoBehaviour
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
        musicBoxOpenedUI.SetActive(false);
        musicBoxLockedUI.SetActive(false);
        StartCoroutine("OpenMusicBox");
    }
    void Update()
    {
       OpenMusicBox();
    }


    IEnumerable OpenMusicBox()
    {
       if (hasKey == true)
        {
            musicBoxOpenedUI.SetActive(true);
            yield return new WaitForSeconds(5);
            musicBoxOpenedUI.SetActive(false);
            musicBoxvideo.GetComponent<AudioSource>().Play();
            
        } else if (hasKey == null)
        {
            musicBoxLockedUI.SetActive(true);
            yield return new WaitForSeconds(5);
            musicBoxLockedUI.SetActive(false);
        }
    }

    

}
