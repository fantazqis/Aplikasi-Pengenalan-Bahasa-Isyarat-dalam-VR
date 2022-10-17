using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlphabetRandomQuestion : MonoBehaviour
{
    AlphabetGuessingGameManager alphabetGuessingGameManager;
    public GestureInput gestureInput;
    public TMP_Text randomLetter;

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
            //numOfQuestion--;
            alphabetGuessingGameManager.correctAnswer += 1;
            Question();
            Debug.Log("nomor 4");
            Debug.Log(gestureInput.userInput);
        }



        else
        {
            Debug.Log("nomor 5");
            Debug.Log(gestureInput.userInput);
            //answerNum.text = GestureInput.userInput.ToString();
            //answerText.text = "jawaban salah";
            Debug.Log("nomor 6");
            Debug.Log(gestureInput.userInput);
        }
        // When the Oculus hand had his time to initialize hand, with a simple coroutine i start a delay of
        // a function to initialize the script

    }

    void Question()
    {
        /*
        if (numOfQuestion == 0)
        {
            alphabetGuessingGameManager.GameFinish();

        }
        */
        Debug.Log("nomor 1");
        Debug.Log(gestureInput.userInput);
        numToGuess = letterToSpawn[Random.Range(0, letterToSpawn.Length - 1)];
        randomLetter.text = numToGuess;

        Debug.Log("nomor 2");
        Debug.Log(gestureInput.userInput);




    }
}
