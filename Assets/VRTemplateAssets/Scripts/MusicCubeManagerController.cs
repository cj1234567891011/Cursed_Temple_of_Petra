using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicCubeManagerController : MonoBehaviour
{
    //List correctMelody = [note1];
    [SerializeField] 
    private List<string> correctMelody; // = new List<AudioClip>("note2", "note3", "note1", "note 2", "note3");
    public List<string> playedMelody;

    public Canvas rightSequence;

    public Canvas wrongSequence;

    public GameObject musicCube1;
    public GameObject musicCube2;
    public GameObject musicCube3;


    public AudioSource music1;
    public AudioSource music2;
    public AudioSource music3;
    

    public CanvasGroup clue3Canvas;
    private bool isCorrect = false;

    
    void Start()
    {
        correctMelody = new List<string>();
        playedMelody = new List<string>();
        rightSequence.gameObject.SetActive(false);
        wrongSequence.gameObject.SetActive(false);
    }

    void NextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Ending");
    }

    public void AddNoteToMelody(string note)
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
            
            for (int i = 0; i < correctMelody.Count; i++)
            {
                if (playedMelody[i] != correctMelody[i])
                {
                    isCorrect = false;
                    break;
               }
            }
            isCorrect = true;

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
    
    


  
}
