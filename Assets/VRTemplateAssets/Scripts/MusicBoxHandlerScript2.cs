using UnityEngine;
using UnityEngine.Events;

public class MusicBoxHandlerScript2 : MonoBehaviour
{
   [SerializeField]
   private GameObject musicBox;
   private GameObject gameManager;
   private GameObject musicBoxUI;
   private GameObject lockedBoxUI;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (musicBoxUIPanel != null) musicBoxUIPanel.SetActive(false);
        if (lockedHintUIPanel != null) lockedHintUIPanel.SetActive(false);
    
    }

    
    void AttemptLockBox()
    {
        if(gameManager.hasKey)
        {
            musicBoxUI.SetActive(true);
        }
        else
        {
            lockedBoxUI.SetActive(true);
            Invoke("HideLockedMessage", 5f);
        }
    }


    private void HideLockedMessage()
    {
        if (lockedBoxUI != null)
        {
            lockedBoxUI.SetActive(false);
        }
    }
}
