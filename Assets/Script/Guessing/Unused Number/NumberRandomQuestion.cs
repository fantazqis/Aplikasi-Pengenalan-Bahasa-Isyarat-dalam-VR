using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberRandomQuestion : MonoBehaviour
{
    public NumberGuessingGameManager numberGuessingGameManager;
    public GestureInput gestureInput;
    public TMP_Text randomLetter;
    public TMP_Text numques;

    //public TextMeshPro RandomQuestion;
    //public int numOfQuestion;
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
            Debug.Log("nomor 3");
            Debug.Log(gestureInput.userInput);
            //answerText.text = "jawaban benar";
            numberGuessingGameManager.correctAnswer += 1;
            Question();
            Debug.Log("nomor 4");
            Debug.Log(gestureInput.userInput);
        }

        // When the Oculus hand had his time to initialize hand, with a simple coroutine i start a delay of
        // a function to initialize the script

    }

    public void Question()
    {
        
        /*
        if (numOfQuestion == 0)
        {
            numberGuessingGameManager.timerIsRunning = false;
            numberGuessingGameManager.GameFinish();

        }
        */
        //numOfQuestion--;
        Debug.Log("nomor 1");
        Debug.Log(gestureInput.userInput);
        numToGuess = letterToSpawn[Random.Range(0, letterToSpawn.Length - 1)];
        randomLetter.text = numToGuess;

        Debug.Log("nomor 2");
        Debug.Log(gestureInput.userInput);




    }
}
