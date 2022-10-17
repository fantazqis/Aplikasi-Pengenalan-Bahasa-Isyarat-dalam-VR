using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TypingGameManager : MonoBehaviour
{
    [Header("Manager References")]
    public SpriteManager spriteManager;
    public AudioSource correctAnswerSound;
    public AudioSource wrongAnswerSound;

    [Header("Timer")]
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreCounterTesting;

    [Header("Heart")]
    public int correctAnswer;
    public int wrongAnswer;
    public int score = 0;
    public GameObject[] redCross;

    [Header("true = Alphabet, false = number")]
    public bool typingMode;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject RedCross in redCross)
        {
            RedCross.gameObject.SetActive(false);
        }
        // Starts the timer automatically
        timerIsRunning = true;
        PlayerPrefs.SetInt("Score", score);
    }

    // Update is called once per frame
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
        timeRemaining = 0;
        timerIsRunning = false;

        PlayerPrefs.SetString("PlayerScore", "Alphabet_Typing");

        PlayerPrefs.SetInt("AlphabetTypingScore", score);

        if (score > PlayerPrefs.GetInt("AlphabetTypingHighScore"))
        {
            PlayerPrefs.SetInt("AlphabetTypingHighScore", score);
        }

        SceneManager.LoadScene("Player_Score_Scene");

    }

    public void GameFinishNumber()
    {
        timeRemaining = 0;
        timerIsRunning = false;

        PlayerPrefs.SetString("PlayerScore", "Number_Typing");

        PlayerPrefs.SetInt("NumberTypingScore", score);

        if (score > PlayerPrefs.GetInt("NumberTypingHighScore"))
        {
            PlayerPrefs.SetInt("NumberTypingHighScore", score);
        }

        SceneManager.LoadScene("Player_Score_Scene");

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
            GameFinishMode();
        }

        else
        {
            spriteManager.Change();
        }
    }
}
