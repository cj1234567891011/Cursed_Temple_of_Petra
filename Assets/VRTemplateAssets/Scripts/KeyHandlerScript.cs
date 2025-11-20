using UnityEngine;
using UnityEngine.Events;

public class KeyHandlerScript : MonoBehaviour
{
    [SerializeField] 
    private GameObject key;
    private GameObject musicBox;
    private GameObject keyUIPrompt;
    private GameObject gameManager;
    


    public bool hasKey = false;
    public UnityEvent onKeyCollected;


    void Start()
    {
        gameManager = FindAnyObjectByType<GameManagerScript>();

        if(keyUIPrompt != null)
        {
            keyUIPrompt.SetActive(false);
        }

    }


    void GrabKey()
    {
         if (!hasKey)
        {
            hasKey = true;
            Debug.Log("Player has the key");

            if(keyUIPrompt != null)
            {
                keyUIPrompt.SetActive(true);
            }
        }

        onKeyCollected.Invoke();

        Destroy(gameObject);
    }

    

}
