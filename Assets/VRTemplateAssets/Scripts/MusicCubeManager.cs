using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicCubeManager : MonoBehaviour
{
    [SerializeField]
    private List<string> correctMelody;

    public List<string> playedMelody;

    public Canvas rightSequence;
    public Canvas wrongSequence;

    void Start()
    {
        correctMelody = new List<string> { "A", "B", "C" };

        playedMelody = new List<string>();
        rightSequence.gameObject.SetActive(false);
        wrongSequence.gameObject.SetActive(false);
    }

    public void AddNoteToMelody(string note)
    {
        playedMelody.Add(note);
        CheckMelody();
    }

    void CheckMelody()
    {
        if (playedMelody.Count < correctMelody.Count)
            return;

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
            rightSequence.gameObject.SetActive(true);
            wrongSequence.gameObject.SetActive(false);
            Invoke(nameof(NextScene), 2f);
        }
        else
        {
            wrongSequence.gameObject.SetActive(true);
            rightSequence.gameObject.SetActive(false);
            playedMelody.Clear();
        }
    }

    void NextScene()
    {
        SceneManager.LoadScene("Ending");
    }
}
