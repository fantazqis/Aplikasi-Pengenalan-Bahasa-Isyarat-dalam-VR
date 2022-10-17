using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyboardFunction : MonoBehaviour
{
    public SpriteManager spriteManager;

    public TMP_InputField inputField;
    public TextMeshPro playerStat;
    public GameObject normalButtons;
    public TypingGameManager typingGameManager;

    // Start is called before the first frame update
    void Start()
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
            typingGameManager.correctAnswer += 1;
            typingGameManager.score += 100;

            typingGameManager.correctAnswerSound.Play();
            //typingGameManager.timeRemaining = 10;

            typingGameManager.DifficultyLevel(typingGameManager.correctAnswer);
        }

        else if (userInput != spriteManager.SpriteToSpawn)
        {
            typingGameManager.wrongAnswer += 1;
            typingGameManager.wrongAnswerSound.Play();
            typingGameManager.redCross[typingGameManager.wrongAnswer - 1].SetActive(true);

            if (typingGameManager.wrongAnswer == 3)
            {
                typingGameManager.GameFinishMode();
            }

            else
            {
                Debug.Log("switch active");
                typingGameManager.DifficultyLevel(typingGameManager.correctAnswer);
            }

        }



    }
}
