using System.Threading.Tasks;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public string note1;
    public string note2;
    public string note3;

    private MusicCubeManagerController musicCubeManagerController;

    public AudioSource musicCubeSound1;
    public AudioSource musicCubeSound2; 
    public AudioSource musicCubeSound3;

    public AudioClip musicCubeNote1;
    public AudioClip musicCubeNote2; 
    public AudioClip musicCubeNote3;

    private bool isNotePlayed = false;

    void Start()
    {
        musicCubeSound1 = GetComponent<AudioSource>();
        musicCubeSound2 = GetComponent<AudioSource>();
        musicCubeSound3 = GetComponent<AudioSource>();

        musicCubeSound1.clip = musicCubeNote1;
        musicCubeSound2.clip = musicCubeNote2;
        musicCubeSound3.clip = musicCubeNote3;
    }


    void Awake()
    {
        musicCubeManagerController = FindObjectOfType<MusicCubeManagerController>();



    }

    void AddNoteToMelody(string note)
    {
        musicCubeManagerController.AddNoteToMelody(note);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "HandColliderLeft" || collision.gameObject.name == "HandColliderRight")
        {
            if (this.gameObject.name == "MusicCube1")
            {
                musicCubeSound1.Play();
                musicCubeManagerController.AddNoteToMelody(note1);
                isNotePlayed = true;
            }
            else if (this.gameObject.name == "MusicCube2")
            {
                musicCubeSound2.Play();
                musicCubeManagerController.AddNoteToMelody(note2);
                isNotePlayed = true;
            }
            else if (this.gameObject.name == "MusicCube3")
            {
                musicCubeSound3.Play();
                musicCubeManagerController.AddNoteToMelody(note3);
                isNotePlayed = true;
            }

            Invoke(nameof(ResetReadyState), 0.2f);
        }
    }

    //Check later if this works
    async Task ResetReadyState()
    {
        isNotePlayed = false;
        await Task.CompletedTask;
        isNotePlayed = true;

    }
}
