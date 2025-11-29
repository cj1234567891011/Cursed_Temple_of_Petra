using System.Collections;
using UnityEngine;

public class KeyHandler : MonoBehaviour
{
    public static bool KeyCollected { get; private set; }

    [SerializeField]
    private CanvasGroup KeyCollectedUI;

    void Start()
    {
        if (KeyCollectedUI != null)
            KeyCollectedUI.gameObject.SetActive(false);
    }

    public void TryCollectKey()
    {
        if (KeyCollected) return;

        KeyCollected = true;
        StartCoroutine(HandleKeyCollectionSequence());
    }

    private IEnumerator HandleKeyCollectionSequence()
    {
        if (KeyCollectedUI != null)
        {
            KeyCollectedUI.gameObject.SetActive(true);
            yield return new WaitForSeconds(3f);
            KeyCollectedUI.gameObject.SetActive(false);
            Debug.Log("[KeyHandler] Key collected!");
            Debug.Log(KeyCollected);
        }
        else
        {
            Debug.LogWarning("KeyCollectedUI is not assigned in the inspector.");
        }

        Destroy(gameObject);
    }
}
