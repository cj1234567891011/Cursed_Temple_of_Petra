using System.Collections;
using UnityEngine;


public class KeyHandler : MonoBehaviour
{
    
    [SerializeField] 
    private CanvasGroup KeyCollectedUI;
    public bool hasKey;
    
    void Start()
    {
        hasKey = false;
    }

    
   

    void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.name == "HandColliderLeft" || collision.gameObject.name == "HandColliderRight")
        {
            if (!hasKey && this.gameObject.name == "Key")
            {
                InteractWithKey();
            }

            
        }
    }

    void InteractWithKey()
    {
        if (!hasKey)
        {
            hasKey = true;
            StartCoroutine(HandleKeyCollectionSequence());
        }
    }

   private IEnumerator HandleKeyCollectionSequence()
    {
       
        if (KeyCollectedUI != null)
        {
            KeyCollectedUI.gameObject.SetActive(true);
            yield return new WaitForSeconds(3f); 
            KeyCollectedUI.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("KeyCollectedUI is not assigned in the inspector.");
        }

            GameObject.Destroy(this.gameObject);
            
    
    }
}
