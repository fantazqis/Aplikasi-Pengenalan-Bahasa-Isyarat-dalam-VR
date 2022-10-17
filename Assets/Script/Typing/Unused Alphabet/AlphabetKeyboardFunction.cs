using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlphabetKeyboardFunction : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteManager spriteManager;

    public TMP_InputField inputField;
    public TextMeshPro playerStat;
    public GameObject normalButtons;
    public AlphabetTypingGameManager alphabetTypingGameManager;


    private void Start()
    {

    }
    public void InsertChar(string c)
    {
        inputField.text += c;
    }

    public void DeleteChar()
    {
        if (inputField.text.Length > 0)
        {
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
        }
    }

    public void TakeText()
    {
        string userInput = inputField.text;

        inputField.Select();
        inputField.text = "";


        if (userInput == spriteManager.SpriteToSpawn)
        {
            alphabetTypingGameManager.correctAnswer += 1;
            alphabetTypingGameManager.score += 100;

            alphabetTypingGameManager.correctAnswerSound.Play();
            //typingGameManager.timeRemaining = 10;

            alphabetTypingGameManager.DifficultyLevel(alphabetTypingGameManager.correctAnswer);
        }

        else if (userInput != spriteManager.SpriteToSpawn)
        {
            alphabetTypingGameManager.wrongAnswer += 1;
            alphabetTypingGameManager.wrongAnswerSound.Play();
            alphabetTypingGameManager.redCross[alphabetTypingGameManager.wrongAnswer - 1].SetActive(true);

            if (alphabetTypingGameManager.wrongAnswer == 3)
            {
                alphabetTypingGameManager.GameFinish();
            }

            else
            {
                Debug.Log("switch active");
                alphabetTypingGameManager.DifficultyLevel(alphabetTypingGameManager.correctAnswer);
            }

            /*
            if (typingGameManager.wrongAnswer == 3)
            {
                typingGameManager.NumOfHeart();
            }

            else
            {
                wordManager.Change();
            }
            */
        }



    }
}
