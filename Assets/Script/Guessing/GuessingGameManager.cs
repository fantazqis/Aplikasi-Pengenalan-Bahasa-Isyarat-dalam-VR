using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GuessingGameManager : MonoBehaviour
{
    public AudioSource correctAnswerSound;

    [Header("Timer")]
    public float timeRemaining = 20;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreCounterTesting;

    [Header("Heart")]
    public int correctAnswer = 0;
    public int score = 0;
    public int pointsPerAnswer = 20;

    [Header("true = Alphabet, false = number")]
    public bool typingMode;

    private void Start()
    {
        PlayerPrefs.SetInt("AlphabetGuessingScore", score);
        PlayerPrefs.SetInt("NumberGuessingScore", score);
        timerIsRunning = true;
        //StartCoroutine(DelayDialogue(10));
    }

    void Update()
    {

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                GameFinishMode();
            }
        }
    }
    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        scoreCounterTesting.text = score.ToString();
    }

    public void GameFinishMode()
    {

        if (typingMode == true)
        {
            GameFinishAlphabet();
        }

        else if (typingMode == false)
        {
            GameFinishNumber();
        }
    }

    public void GameFinishAlphabet()
    {
        score = correctAnswer * pointsPerAnswer;

        timeRemaining = 0;
        timerIsRunning = false;

        PlayerPrefs.SetString("PlayerScore", "Alphabet_Guessing");

        PlayerPrefs.SetInt("AlphabetGuessingScore", score);

        if (score > PlayerPrefs.GetInt("AlphabetGuessingHighScore"))
        {
            PlayerPrefs.SetInt("AlphabetGuessingHighScore", score);
        }

        SceneManager.LoadScene("Player_Score_Scene");

    }

    public void GameFinishNumber()
    {
        score = correctAnswer * pointsPerAnswer;

        timeRemaining = 0;
        timerIsRunning = false;

        PlayerPrefs.SetString("PlayerScore", "Number_Guessing") ;

        PlayerPrefs.SetInt("NumberGuessingScore", score);

        if (score > PlayerPrefs.GetInt("NumberGuessingHighScore"))
        {
            PlayerPrefs.SetInt("NumberGuessingHighScore", score);
        }

        SceneManager.LoadScene("Player_Score_Scene");

    }
}
