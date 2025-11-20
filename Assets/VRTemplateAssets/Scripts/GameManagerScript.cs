using UnityEngine;
using UnityEngine.Events;

public class GameManagerScript : MonoBehaviour
{
    
    [SerializeField]
    private GameObject keyUIPrompt;

    public bool hasKey = false;

    public UnityEvent onKeyCollected;
   
    
    void Update()
    {
        
    }
}
