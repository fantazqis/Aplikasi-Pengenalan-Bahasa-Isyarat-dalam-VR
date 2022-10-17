using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningSoundManager : MonoBehaviour
{

    public LearningGameManager learningGameManager;

    public AudioSource dingSource;

    public AudioSource dialogueSourceAlphabet;
    public AudioSource dialogueSourceNumber;

    public static LearningSoundManager instance = null;

    public List<AudioClip> dialogueAlphabet;
    public List<AudioClip> dialogueNumber;

    public AudioClip ding;

    /*
    void Awake()
    {
        if (instance == null)

            instance = this;

        else if (instance != null && instance != this)

            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    */

    private IEnumerator WaitAudioAlphabet(int i)
    {
        yield return new WaitForSeconds(dialogueSourceAlphabet.clip.length);
        print("end of sound");
        learningGameManager.DialogueFinishedAlphabet(i);
    }

    public void PlayDialogueAlphabet(int dialogueID)
    {
        dialogueSourceAlphabet.clip = dialogueAlphabet[dialogueID];

        dialogueSourceAlphabet.Play();

        StartCoroutine(WaitAudioAlphabet(dialogueID));
    }

    private IEnumerator WaitAudioNumber(int i)
    {
        yield return new WaitForSeconds(dialogueSourceNumber.clip.length);
        print("end of sound");
        learningGameManager.DialogueFinishedNumber(i);
    }

    public void PlayDialogueNumber(int dialogueID)
    {
        dialogueSourceNumber.clip = dialogueNumber[dialogueID];

        dialogueSourceNumber.Play();

        StartCoroutine(WaitAudioNumber(dialogueID));
    }

    public void PlayDing()
    {
        dingSource.clip = ding;
        dingSource.Play();
    }
}
