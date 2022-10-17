using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerAlphabet : MonoBehaviour
{

    [Header("Manager References")]
    public SoundManagerAlphabet soundManager;
    public GestureInput gestureInputAlphabet;
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
        StartCoroutine(DelayDialogue(6, currentDialogue));
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
                StartCoroutine(DetectA());
                break;

            case 5:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectB());
                break;

            case 6:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectC());
                break;

            case 7:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectD());
                break;

            case 8:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectE());
                break;

            case 9:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectF());
                break;

            case 10:
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
                    currentDialogue = 12;
                    imgSibi++;
                }

                foreach (GameObject sibi in sibiGuides)
                {
                    sibi.GetComponent<SpriteRenderer>().enabled = false;
                }
                speechText.text = dialogueText[currentDialogue];
                soundManager.PlayDialogue(currentDialogue);
                break;
            /// <summary>
            /// masih bingung kalimat setelah menyelesaikan huruf F
            /// </summary>
            /// <returns></returns>

            case 11:
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

                    StartCoroutine(DetectA());

                }

                else if (repeatSibi == 2)
                {

                    StartCoroutine(DetectG());
                }

                else if (repeatSibi == 3)
                {

                    StartCoroutine(DetectM());
                }

                else
                {

                    StartCoroutine(DetectT());
                }
                break;

            case 12:
                sibiGuides[1].GetComponent<SpriteRenderer>().enabled = true;
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectG());
                break;

            case 13:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectH());
                break;

            case 14:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectI());
                break;

            case 15:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectJ());
                break;

            case 16:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectK());
                break;

            case 17:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectL());
                break;

            case 18:
                speechText.text = "";
                speaking = false;
                if (repeatSibi == 1)
                {
                    interactionImg2.GetComponent<SpriteRenderer>().enabled = true;
                    currentDialogue = 11;
                }

                else
                {
                    interactionImg2.GetComponent<SpriteRenderer>().enabled = false;
                    currentDialogue = 19;
                    imgSibi++;
                }

                foreach (GameObject sibi in sibiGuides)
                {
                    sibi.GetComponent<SpriteRenderer>().enabled = false;
                }
                speechText.text = dialogueText[currentDialogue];
                soundManager.PlayDialogue(currentDialogue);
                break;

            case 19:
                sibiGuides[2].GetComponent<SpriteRenderer>().enabled = true;
                currentDialogue++;
                speechText.text = dialogueText[currentDialogue];
                soundManager.PlayDialogue(currentDialogue);
                break;

            case 21:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectM());
                break;

            case 22:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectN());
                break;

            case 23:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectO());
                break;

            case 24:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectP());
                break;

            case 25:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectQ());
                break;

            case 26:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectR());
                break;

            case 27:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectS());
                break;

            case 28:
                speechText.text = "";
                speaking = false;
                if (repeatSibi == 2)
                {
                    interactionImg2.GetComponent<SpriteRenderer>().enabled = true;
                    currentDialogue = 11;
                }

                else
                {
                    interactionImg2.GetComponent<SpriteRenderer>().enabled = false;
                    currentDialogue = 29;
                    imgSibi++;
                }

                foreach (GameObject sibi in sibiGuides)
                {
                    sibi.GetComponent<SpriteRenderer>().enabled = false;
                }
                speechText.text = dialogueText[currentDialogue];
                soundManager.PlayDialogue(currentDialogue);
                break;

            case 29:
                sibiGuides[3].GetComponent<SpriteRenderer>().enabled = true;
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectT());
                break;

            case 30:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectU());
                break;

            case 31:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectV());
                break;

            case 32:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectW());
                break;

            case 33:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectX());
                break;

            case 34:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectY());
                break;

            case 35:
                speechText.text = "";
                speaking = false;
                StartCoroutine(DetectZ());
                break;

            case 36:
                speechText.text = "";
                speaking = false;
                if (repeatSibi == 3)
                {
                    interactionImg2.GetComponent<SpriteRenderer>().enabled = true;
                    currentDialogue = 11;
                }

                else
                {
                    interactionImg2.GetComponent<SpriteRenderer>().enabled = false;
                    currentDialogue = 37;
                }

                foreach (GameObject sibi in sibiGuides)
                {
                    sibi.GetComponent<SpriteRenderer>().enabled = false;
                }
                speechText.text = dialogueText[currentDialogue];
                soundManager.PlayDialogue(currentDialogue);
                break;

            case 38:
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


    IEnumerator ChooseMode()
    {
        yield return new WaitForSeconds(3);
        yield return new WaitUntil(() => gestureInputInteraction.userInput == "Okay" || gestureInputInteraction.userInput == "Grip" || gestureInputInteraction.userInput == "Thumbs Down");
        soundManager.PlayDing();
        interactionImg.GetComponent<SpriteRenderer>().enabled = false;

        if (gestureInputInteraction.userInput == "Okay")
        {
            Debug.Log("ChooseMode Alphabet");
            currentDialogue = 8;
            gameMode = "Alphabet";
            speechText.text = dialogueText[currentDialogue];
            soundManager.PlayDialogue(currentDialogue);
        }
        else if (gestureInputInteraction.userInput == "Grip")
        {
            Debug.Log("ChooseMode Number");
            currentDialogue = 8;
            gameMode = "Number";
            speechText.text = dialogueText[currentDialogue];
            soundManager.PlayDialogue(currentDialogue);
        }
        else if (gestureInputInteraction.userInput == "Thumbs Down")
        {
            SceneManager.LoadScene("IntroductionScene");
            //Application.Quit();
        }
    }


    void DialogueMode(int dialogue)
    {
        Debug.Log("DialogueMode");
        if (gameMode == "Alphabet")
        {
            Debug.Log("DialogueMode alphabet");
            currentDialogue = 12;
            speechText.text = dialogueText[currentDialogue];
            soundManager.PlayDialogue(currentDialogue);
        }
        else if (gameMode == "Number")
        {
            Debug.Log("DialogueMode number");
            currentDialogue = 50;
            speechText.text = dialogueText[currentDialogue];
            soundManager.PlayDialogue(currentDialogue);
        }
    }

    IEnumerator DetectA()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "A" && !speaking);
        speaking = true;
        currentDialogue = 14;
        //currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectB()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "B" && !speaking);
        speaking = true;
        //currentDialogue = 15;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectC()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "C" && !speaking);
        speaking = true;
        //currentDialogue = 16;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectD()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "D" && !speaking);
        speaking = true;
        //currentDialogue = 17;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectE()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "E" && !speaking);
        speaking = true;
        //currentDialogue = 18;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectF()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "F" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    /// <summary>
    /// masih belum pasti urutan current dialogue
    /// </summary>
    /// <returns></returns>
    IEnumerator DetectG()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "G" && !speaking);
        speaking = true;
        //current dialogue masih belum pasti
        currentDialogue = 22;
        //currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectH()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "H" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectI()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "I" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectJ()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "J" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectK()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "K" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectL()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "L" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectM()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "M" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue = 32;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectN()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "N" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectO()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "O" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectP()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "P" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectQ()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "Q" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectR()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "R" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectS()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "S" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectT()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "T" && !speaking);
        speaking = true;
        currentDialogue = 40;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectU()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "U" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectV()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "V" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectW()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "W" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectX()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "X" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectY()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "Y" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        soundManager.PlayDialogue(currentDialogue);
    }

    IEnumerator DetectZ()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "Z" && !speaking);
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

    /*
    IEnumerator DetectChoice()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "Okay" || gestureInputInteraction.userInput == "Thumbs Down");
        Debug.Log("Case detect choice ");
        soundManager.PlayDing();
        warningImg.GetComponent<SpriteRenderer>().enabled = false;

        if (gestureInputInteraction.userInput == "Okay")
        {
            Debug.Log("Case Okay");
            currentDialogue = 8;
            speechText.text = dialogueText[currentDialogue];
            soundManager.PlayDialogue(currentDialogue);
        }
        else if (gestureInputInteraction.userInput == "Thumbs Down")
        {
            Debug.Log("Case Thumb down");
            currentDialogue = 6;
            speechText.text = dialogueText[currentDialogue];
            soundManager.PlayDialogue(currentDialogue);
        }
    }
    */
}
