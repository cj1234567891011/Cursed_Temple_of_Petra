using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicCubeManagerController : MonoBehaviour
{
    //List correctMelody = [note1];
    [SerializeField] 
    private List<AudioClip> correctMelody;
    public List<AudioClip> playedMelody;

    public Canvas rightSequence;

    public Canvas wrongSequence;

    public GameObject musicCube1;
    public GameObject musicCube2;
    public GameObject musicCube3;


    public AudioSource music1;
    public AudioSource music2;
    public AudioSource music3;
    public SceneManager sceneManager;
    
    void Start()
    {
        correctMelody = new List<AudioClip>();
        playedMelody = new List<AudioClip>();
        rightSequence.enabled = false;
        wrongSequence.enabled = false;
    }


    public void AddNoteToMelody(AudioClip note)
    {
        while(playedMelody.Count < correctMelody.Count)
        {
            playedMelody.Add(note);
            CheckMelody();
            break;
        }
    }

    void CheckMelody()
    {
        if (playedMelody.Count == correctMelody.Count)
         {
            bool isCorrect = true;
            for (int i = 0; i < correctMelody.Count; i++)
            {
                if (playedMelody[i] != correctMelody[i])
                {
                    isCorrect = false;
                    break;
               }
            }

            if (isCorrect)
            {
                rightSequence.enabled = true;
                wrongSequence.enabled = false;
            }
            else
            {
                wrongSequence.enabled = true;
                rightSequence.enabled = false;
            }

            playedMelody.Clear();
            NextScene();
        }
    }
    
    void NextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("OutroScene");
    }


    internal void AddNoteToMelody(string note1)
    {
        throw new NotImplementedException();
    }
}
