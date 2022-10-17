using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerNumber : MonoBehaviour
{
    
    [Header("Manager References")]
    public SoundManagerNumber soundManager;
    public GestureInput gestureInputNumber;
    public GestureInput gestureInputInteraction;

    [Header("Displayed Dialogue")]
    [TextArea]
    public string[] dialogueText;

    [Header("Manipulated Objects")]
    public TextMeshPro speechText;
    public GameObject interactionImg;
    public GameObject interactionImg2;
    public GameObject[] sibiGuides;
    public GameObject[] gestureDetector;

    /// <summary> Dialogue index that needs to be played next </summary>
    private int currentDialogue = 0;

    /// <summary> Variable to know if its number or alphabet </summary>
    private string gameMode;

    /// <summary> Distance the player's arm must be extended for primary hand setting </summary>
    //private readonly float extendedValue = 0.44f;

    /// <summary> Used in the demo to track how many gestures have been made in the first test </summary>
    //private int numGestures = 0;

    /// <summary>
    /// Tracks if the demo is running. If the demo is not active, gesture coroutines stay on and turn themselves on after running
    /// </summary>
    //private bool demoActive = true;

    /// <summary>
    /// Tracks if the narrator is speaking due to gesture detection and prevents overlap if so
    /// </summary>
    private bool speaking = false;

    /// <summary> Rounds of rock paper scissors completed in the demo </summary>
    private int imgSibi = 0;

    /// <summary> What part of ASL portion the player is currently on </summary>
    private int repeatSibi = 0;

    void Start()
    {
        Debug.Log("Start " + currentDialogue);
        StartCoroutine(DelayDialogue(5, currentDialogue));
    }

    public void DialogueFinished(int i)
    {
        
        switch (i)
        {
            case 3:
                sibiGuides[0].GetComponent<SpriteRenderer>().enabled = true;
                gestureDetector[0].gameObject.SetActive(true);
                currentDialogue++;
                speechText.text = dialogueText[currentDialogue];
                soundManager.PlayDialogue(currentDialogue);
                break;

            case 4:
                StartCoroutine(Detect1());
                break;

            case 5:
                speechText.text = "";
                speaking = false;
                StartCoroutine(Detect2());
                break;

            case 6:
                speechText.text = "";
                speaking = false;
                StartCoroutine(Detect3());
                break;

            case 7:
                speechText.text = "";
                speaking = false;
                StartCoroutine(Detect4());
                break;

            case 8:
                speechText.text = "";
                speaking = false;
                StartCoroutine(Detect5());
                break;

            case 9:
                speechText.text = "";
                speaking = false;
                if (repeatSibi == 0)
                {
                    interactionImg2.GetComponent<SpriteRenderer>().enabled = true;
                    Debug.Log("Case 58 IF IF");
                    currentDialogue++;
                }

                else
                {
                    interactionImg2.GetComponent<SpriteRenderer>().enabled = false;
                    Debug.Log("Case 58 IF ELSE ");
                    currentDialogue = 11;
                    imgSibi++;
                }

                foreach (GameObject sibi in sibiGuides)
                {
                    sibi.GetComponent<SpriteRenderer>().enabled = false;
                }
                speechText.text = dialogueText[currentDialogue];
                soundManager.PlayDialogue(currentDialogue);
                break;

            case 10:
                repeatSibi++;
                foreach (GameObject sibi in sibiGuides)
                {
                    sibi.GetComponent<SpriteRenderer>().enabled = false;
                }
                StopAllCoroutines();
                // ADD COROUTINE FOR SNAPPING
                StartCoroutine(DetectSnap());
                //baru sampe sini

                if (repeatSibi == 1)
                {

                    StartCoroutine(Detect1());

                }

                else if (repeatSibi == 2)
                {

                    StartCoroutine(Detect6());
                }
                break;

            case 11:
                sibiGuides[1].GetComponent<SpriteRenderer>().enabled = true;
                speechText.text = "";
                speaking = false;
                StartCoroutine(Detect6());
                break;

            case 12:
                speechText.text = "";
                speaking = false;
                StartCoroutine(Detect7());
                break;

            case 13:
                speechText.text = "";
                speaking = false;
                StartCoroutine(Detect8());
                break;

            case 14:
                speechText.text = "";
                speaking = false;
                StartCoroutine(Detect9());
                break;

            case 15:
                speechText.text = "";
                speaking = false;
                StartCoroutine(Detect10());
                break;

            case 16:
                speechText.text = "";
                speaking = false;
                if (repeatSibi == 1)
                {
                    interactionImg2.GetComponent<SpriteRenderer>().enabled = true;
                    currentDialogue = 10;
                }

                else
                {
                    interactionImg2.GetComponent<SpriteRenderer>().enabled = false;
                    currentDialogue = 17;
                }

                foreach (GameObject sibi in sibiGuides)
                {
                    sibi.GetComponent<SpriteRenderer>().enabled = false;
                }
                speechText.text = dialogueText[currentDialogue];
                soundManager.PlayDialogue(currentDialogue);
                break;
            case 18:
                SceneManager.LoadScene("LearningIntroduction");
                break;

            default:
                currentDialogue++;
                speechText.text = dialogueText[currentDialogue];
                soundManager.PlayDialogue(currentDialogue);
                break;
        }
    }

    IEnumerator DelayDialogue(int secs, int dialogue)
    {
        yield return new WaitForSeconds(secs);
        currentDialogue = dialogue;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator Detect1()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "1" && !speaking);
        speaking = true;
        //currentDialogue = 52;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator Detect2()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "2" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator Detect3()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "3" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator Detect4()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "4" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator Detect5()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "5" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator Detect6()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "6" && !speaking);
        speaking = true;
        //currentDialogue = 59;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator Detect7()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "7" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator Detect8()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "8" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator Detect9()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "9" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator Detect10()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "10" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectSnap()
    {
        yield return new WaitUntil(() => gestureInputInteraction.userInput == "Okay" && !speaking);
        soundManager.PlayDing();
        sibiGuides[imgSibi].GetComponent<SpriteRenderer>().enabled = true;
        //rpsPic.GetComponent<MeshRenderer>().enabled = true;
        //speaking = true;
        //currentDialogue = 71;
        //speechText.text = dialogueText[currentDialogue];
        //soundManager.PlayDialogue(currentDialogue);
    }
    
}
