using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuessingRandomQuestion : MonoBehaviour
{
    public GuessingGameManager guessingGameManager;
    public GestureInput gestureInput;
    public TMP_Text randomLetter;

    private string numToGuess;
    public string[] letterToSpawn;
    // Start is called before the first frame update
    private void Start()
    {
        Question();
    }

    void Update()
    {
        if (gestureInput.userInput == numToGuess)
        {
            guessingGameManager.correctAnswer += 1;
            Question();
        }
    }

    public void Question()
    {
        numToGuess = letterToSpawn[Random.Range(0, letterToSpawn.Length - 1)];
        randomLetter.text = numToGuess;
    }
}
