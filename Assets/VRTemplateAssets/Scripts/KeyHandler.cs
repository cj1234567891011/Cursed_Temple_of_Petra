using UnityEngine;

public class KeyHandler : MonoBehaviour
{
    
    [SerializeField] 
    private GameObject KeyCollectedUI;
    public bool hasKey;
    
    void Start()
    {
        hasKey = false;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            InteractWithKey();
        
        }
    }

    void InteractWithKey()
    {
        if (!hasKey)
        {
            hasKey = true;
            KeyCollectedUI.SetActive(true);
            GameObject.Destroy(this.gameObject);
        }
    }
}
