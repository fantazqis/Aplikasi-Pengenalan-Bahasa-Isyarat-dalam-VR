using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueController : MonoBehaviour
{
    public SoundManagerTesting soundManager;
    public GameObject[] buttonToAppear;

    [TextArea]
    public string[] dialogueText;

    public TextMeshPro speechText;

    private int currentDialogue = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        HasTutorial();       
    }

    public void HasTutorial()
    {
        if (PlayerPrefs.GetInt("TutorialPlayed") == 0)
        {
            PlayerPrefs.SetInt("TutorialPlayed", 1);
            StartCoroutine(DelayDialogue(3, currentDialogue));
        }

        else if (PlayerPrefs.GetInt("TutorialPlayed") == 1)
        {
            //ButtonToAppear();
            StartCoroutine(DelayDialogue(3, 7));
        }
    }

    public void DialogueFinished(int i)
    {
        switch (i)
        {
            case 7:
                Debug.Log("case 7");
                ButtonToAppear();
                break;


            default:
                currentDialogue++;
                speechText.text = dialogueText[currentDialogue];
                soundManager.PlayDialogue(currentDialogue);
                break;
        }
    }

    public void ButtonToAppear()
    {
        Debug.Log("case button to appear");
        foreach (GameObject ButtonToDeactivate in buttonToAppear)
        {
            ButtonToDeactivate.gameObject.SetActive(true);
            //Debug.Log("change foreach");
        }
    }
    IEnumerator DelayDialogue(int secs, int dialogue)
    {
        yield return new WaitForSeconds(secs);
        currentDialogue = dialogue;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }
}
