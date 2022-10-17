using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberKeyboardFunction : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteManager spriteManager;

    public TMP_InputField inputField;
    public TextMeshPro playerStat;
    public GameObject normalButtons;
    public NumberTypingGameManager numberTypingGameManager;


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
            numberTypingGameManager.correctAnswer += 1;
            numberTypingGameManager.score += 100;

            numberTypingGameManager.correctAnswerSound.Play();
            //typingGameManager.timeRemaining = 10;

            numberTypingGameManager.DifficultyLevel(numberTypingGameManager.correctAnswer);
        }

        else if (userInput != spriteManager.SpriteToSpawn)
        {
            numberTypingGameManager.wrongAnswer += 1;
            numberTypingGameManager.wrongAnswerSound.Play();
            numberTypingGameManager.redCross[numberTypingGameManager.wrongAnswer - 1].SetActive(true);

            if (numberTypingGameManager.wrongAnswer == 3)
            {
                numberTypingGameManager.GameFinish();
            }

            else
            {
                Debug.Log("switch active");
                numberTypingGameManager.DifficultyLevel(numberTypingGameManager.correctAnswer);
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
