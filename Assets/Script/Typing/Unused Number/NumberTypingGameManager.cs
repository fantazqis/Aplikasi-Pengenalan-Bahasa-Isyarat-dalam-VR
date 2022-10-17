using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NumberTypingGameManager : MonoBehaviour
{
    public SpriteManager spriteManager;
    public AudioSource correctAnswerSound;
    public AudioSource wrongAnswerSound;


    [Header("Timer")]
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timerText;

    [Header("Heart")]
    public int correctAnswer;
    public int wrongAnswer;
    public int score = 0;
    public GameObject[] redCross;

    private void Start()
    {

        foreach (GameObject RedCross in redCross)
        {
            RedCross.gameObject.SetActive(false);
        }
        // Starts the timer automatically
        timerIsRunning = true;
        PlayerPrefs.SetInt("Score", score);
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
                OutOfTime();
            }
        }
    }
    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;


        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    public void DifficultyLevel(int diff)
    {
        if (6 <= diff && diff <= 10)
        {
            Debug.Log("switch 5");
            timeRemaining = 7;
            spriteManager.Change();
        }

        else if (11 <= diff && diff <= 15)
        {
            Debug.Log("switch 5");
            timeRemaining = 5;
            spriteManager.Change();
        }

        else if (16 <= diff)
        {
            Debug.Log("switch 5");
            timeRemaining = 3;
            spriteManager.Change();
        }

        else
        {
            timeRemaining = 10;
            spriteManager.Change();
        }
    }

    public void GameFinish()
    {
        timeRemaining = 0;
        timerIsRunning = false;

        PlayerPrefs.SetInt("NumberTypingScore", score);

        if (score > PlayerPrefs.GetInt("NumberTypingHighScore"))
        {
            PlayerPrefs.SetInt("NumberTypingHighScore", score);
        }

        SceneManager.LoadScene("FinishNumberTypingScene");

        /*
        if (wrongAnswer == 3)
        {
            PlayerPrefs.SetInt("Score", score);

            if(score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }

            SceneManager.LoadScene("LoseTypingScene");
        }
        */
        /*
        else if(score >= 5000)
        {
            SceneManager.LoadScene("WinTypingScene");
        }
        */
    }

    public void OutOfTime()
    {
        wrongAnswer += 1;
        timeRemaining = 10;
        timerIsRunning = true;
        redCross[wrongAnswer - 1].SetActive(true);

        wrongAnswerSound.Play();
        //DifficultyLevel(wrongAnswer);

        if (wrongAnswer == 3)
        {
            GameFinish();
        }

        else
        {
            spriteManager.Change();
        }
    }
}
