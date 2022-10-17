using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class LearningGameManager : MonoBehaviour
{
    [Header("Manager References")]
    public LearningSoundManager learningSoundManager;
    public GestureInput gestureInputAlphabet;
    public GestureInput gestureInputNumber;
    public GestureInput gestureInputInteraction;

    [Header("Displayed Dialogue")]
    [TextArea]
    public string[] dialogueText;

    [Header("Manipulated Objects")]
    public TextMeshPro speechText;
    public GameObject interactionImg;
    public GameObject[] sibiGuides;
    public GameObject[] gestureDetector;

    private int currentDialogue = 0;

    [Header("true = Alphabet, false = number")]
    public bool learningMode;

    private bool speaking = false;

    private int imgSibi = 0;

    private int repeatSibi = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (learningMode == true)
        {
            StartCoroutine(DelayDialogueAlphabet(3, currentDialogue));
        }

        else if (learningMode == false)
        {
            StartCoroutine(DelayDialogueNumber(3, currentDialogue));
        }
    }

    public void DialogueFinishedAlphabet(int i)
    {
        switch (i)
        {
            case 3:
                sibiGuides[0].GetComponent<SpriteRenderer>().enabled = true;
                //gestureDetector[0].gameObject.SetActive(true);
                currentDialogue++;
                speechText.text = dialogueText[currentDialogue];
                learningSoundManager.PlayDialogueAlphabet(currentDialogue);
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
                    interactionImg.GetComponent<SpriteRenderer>().enabled = true;
                    currentDialogue++;
                }

                else
                {
                    interactionImg.GetComponent<SpriteRenderer>().enabled = false;
                    currentDialogue = 12;
                    imgSibi++;
                }

                foreach (GameObject sibi in sibiGuides)
                {
                    sibi.GetComponent<SpriteRenderer>().enabled = false;
                }
                speechText.text = dialogueText[currentDialogue];
                learningSoundManager.PlayDialogueAlphabet(currentDialogue);
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
                    interactionImg.GetComponent<SpriteRenderer>().enabled = true;
                    currentDialogue = 11;
                }

                else
                {
                    interactionImg.GetComponent<SpriteRenderer>().enabled = false;
                    currentDialogue = 19;
                    imgSibi++;
                }

                foreach (GameObject sibi in sibiGuides)
                {
                    sibi.GetComponent<SpriteRenderer>().enabled = false;
                }
                speechText.text = dialogueText[currentDialogue];
                learningSoundManager.PlayDialogueAlphabet(currentDialogue);
                break;

            case 19:
                sibiGuides[2].GetComponent<SpriteRenderer>().enabled = true;
                currentDialogue++;
                speechText.text = dialogueText[currentDialogue];
                learningSoundManager.PlayDialogueAlphabet(currentDialogue);
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
                    interactionImg.GetComponent<SpriteRenderer>().enabled = true;
                    currentDialogue = 11;
                }

                else
                {
                    interactionImg.GetComponent<SpriteRenderer>().enabled = false;
                    currentDialogue = 29;
                    imgSibi++;
                }

                foreach (GameObject sibi in sibiGuides)
                {
                    sibi.GetComponent<SpriteRenderer>().enabled = false;
                }
                speechText.text = dialogueText[currentDialogue];
                learningSoundManager.PlayDialogueAlphabet(currentDialogue);
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
                    interactionImg.GetComponent<SpriteRenderer>().enabled = true;
                    currentDialogue = 11;
                }

                else
                {
                    interactionImg.GetComponent<SpriteRenderer>().enabled = false;
                    currentDialogue = 37;
                }

                foreach (GameObject sibi in sibiGuides)
                {
                    sibi.GetComponent<SpriteRenderer>().enabled = false;
                }
                speechText.text = dialogueText[currentDialogue];
                learningSoundManager.PlayDialogueAlphabet(currentDialogue);
                break;

            case 38:
                SceneManager.LoadScene("Learning_Main_Menu_Scene");
                break;


            default:
                currentDialogue++;
                speechText.text = dialogueText[currentDialogue];
                learningSoundManager.PlayDialogueAlphabet(currentDialogue);
                break;
        }
    }

    public void DialogueFinishedNumber(int i)
    {

        switch (i)
        {
            case 3:
                sibiGuides[0].GetComponent<SpriteRenderer>().enabled = true;
                //gestureDetector[0].gameObject.SetActive(true);
                currentDialogue++;
                speechText.text = dialogueText[currentDialogue];
                learningSoundManager.PlayDialogueNumber(currentDialogue);
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
                    interactionImg.GetComponent<SpriteRenderer>().enabled = true;
                    currentDialogue++;
                }

                else
                {
                    interactionImg.GetComponent<SpriteRenderer>().enabled = false;
                    currentDialogue = 11;
                    imgSibi++;
                }

                foreach (GameObject sibi in sibiGuides)
                {
                    sibi.GetComponent<SpriteRenderer>().enabled = false;
                }
                speechText.text = dialogueText[currentDialogue];
                learningSoundManager.PlayDialogueNumber(currentDialogue);
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
                    interactionImg.GetComponent<SpriteRenderer>().enabled = true;
                    currentDialogue = 10;
                }

                else
                {
                    interactionImg.GetComponent<SpriteRenderer>().enabled = false;
                    currentDialogue = 17;
                }

                foreach (GameObject sibi in sibiGuides)
                {
                    sibi.GetComponent<SpriteRenderer>().enabled = false;
                }
                speechText.text = dialogueText[currentDialogue];
                learningSoundManager.PlayDialogueNumber(currentDialogue);
                break;
            case 18:
                SceneManager.LoadScene("Learning_Main_Menu_Scene");
                break;

            default:
                currentDialogue++;
                speechText.text = dialogueText[currentDialogue];
                learningSoundManager.PlayDialogueNumber(currentDialogue);
                break;
        }
    }

    IEnumerator DelayDialogueAlphabet(int secs, int dialogue)
    {
        yield return new WaitForSeconds(secs);
        currentDialogue = dialogue;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
    }

    IEnumerator DelayDialogueNumber(int secs, int dialogue)
    {
        yield return new WaitForSeconds(secs);
        currentDialogue = dialogue;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueNumber(currentDialogue);
    }

    IEnumerator DetectSnap()
    {
        yield return new WaitUntil(() => gestureInputInteraction.userInput == "Okay" && !speaking);
        learningSoundManager.PlayDing();
        sibiGuides[imgSibi].GetComponent<SpriteRenderer>().enabled = true;
    }

    IEnumerator DetectA()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "A" && !speaking);
        speaking = true;
        currentDialogue = 5;
        //currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
    }

    IEnumerator DetectB()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "B" && !speaking);
        speaking = true;
        //currentDialogue = 15;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
    }

    IEnumerator DetectC()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "C" && !speaking);
        speaking = true;
        //currentDialogue = 16;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
    }

    IEnumerator DetectD()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "D" && !speaking);
        speaking = true;
        //currentDialogue = 17;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
    }

    IEnumerator DetectE()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "E" && !speaking);
        speaking = true;
        //currentDialogue = 18;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
    }

    IEnumerator DetectF()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "F" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
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
        currentDialogue = 13;
        //currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
    }

    IEnumerator DetectH()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "H" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
    }

    IEnumerator DetectI()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "I" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
    }

    IEnumerator DetectJ()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "J" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
    }

    IEnumerator DetectK()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "K" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
    }

    IEnumerator DetectL()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "L" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
    }

    IEnumerator DetectM()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "M" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue = 22;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
    }

    IEnumerator DetectN()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "N" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
    }

    IEnumerator DetectO()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "O" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
    }

    IEnumerator DetectP()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "P" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
    }

    IEnumerator DetectQ()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "Q" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
    }

    IEnumerator DetectR()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "R" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
    }

    IEnumerator DetectS()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "S" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
    }

    IEnumerator DetectT()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "T" && !speaking);
        speaking = true;
        currentDialogue = 30;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
    }

    IEnumerator DetectU()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "U" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
    }

    IEnumerator DetectV()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "V" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
    }

    IEnumerator DetectW()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "W" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
    }

    IEnumerator DetectX()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "X" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
    }

    IEnumerator DetectY()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "Y" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
    }

    IEnumerator DetectZ()
    {
        yield return new WaitUntil(() => gestureInputAlphabet.userInput == "Z" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueAlphabet(currentDialogue);
    }

    IEnumerator Detect1()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "1" && !speaking);
        speaking = true;
        currentDialogue = 5;
        //currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueNumber(currentDialogue);
    }

    IEnumerator Detect2()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "2" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueNumber(currentDialogue);
    }

    IEnumerator Detect3()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "3" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueNumber(currentDialogue);
    }

    IEnumerator Detect4()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "4" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueNumber(currentDialogue);
    }

    IEnumerator Detect5()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "5" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueNumber(currentDialogue);
    }

    IEnumerator Detect6()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "6" && !speaking);
        speaking = true;
        currentDialogue = 12;
        //currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueNumber(currentDialogue);
    }

    IEnumerator Detect7()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "7" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueNumber(currentDialogue);
    }

    IEnumerator Detect8()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "8" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueNumber(currentDialogue);
    }

    IEnumerator Detect9()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "9" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueNumber(currentDialogue);
    }

    IEnumerator Detect10()
    {
        yield return new WaitUntil(() => gestureInputNumber.userInput == "10" && !speaking);
        speaking = true;
        //currentDialogue = 19;
        currentDialogue++;
        speechText.text = dialogueText[currentDialogue];
        learningSoundManager.PlayDialogueNumber(currentDialogue);
    }
}
