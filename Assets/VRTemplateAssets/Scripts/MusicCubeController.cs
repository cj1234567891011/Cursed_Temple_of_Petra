using UnityEngine;

public class MusicCubeController : MonoBehaviour
{
    public string note;     

    public AudioSource audioSource;  
    public AudioClip noteClip;       

    private MusicCubeManager manager;

    void Awake()
    {
        manager = FindFirstObjectByType<MusicCubeManager>();

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    public void OnCubeSelected()
    {
        Debug.Log($"{gameObject.name} has been touched");

        PlayNote();
        SendNoteToManager();
    }

    private void PlayNote()
    {
        if (audioSource == null || noteClip == null)
        {
            Debug.LogWarning($"{gameObject.name} is missing AudioSource or noteClip");
            return;
        }

        audioSource.clip = noteClip;
        audioSource.Play();
    }

    private void SendNoteToManager()
    {
        if (manager == null)
        {
            Debug.LogWarning($"{gameObject.name} cannot find MusicCubeManager");
            return;
        }

        manager.AddNoteToMelody(note);
    }
}
