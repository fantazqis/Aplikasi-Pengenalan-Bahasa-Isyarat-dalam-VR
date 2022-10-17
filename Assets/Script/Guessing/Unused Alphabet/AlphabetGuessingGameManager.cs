using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AlphabetGuessingGameManager : MonoBehaviour
{
    public AudioSource correctAnswerSound;
    public GameObject warningImage;


    [Header("Timer")]
    public float timeRemaining = 60;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timerText;

    [Header("Heart")]
    public int correctAnswer;
    public int score = 0;
    public int pointsPerSecond = 20;

    private void Start()
    {

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
                GameFinish();
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


    public void GameFinish()
    {
        score = Mathf.FloorToInt(timeRemaining) * pointsPerSecond;

        timeRemaining = 0;
        timerIsRunning = false;

        PlayerPrefs.SetInt("NumberGuessingScore", score);

        if (score > PlayerPrefs.GetInt("NumberGuessingHighScore"))
        {
            PlayerPrefs.SetInt("NumberGuessingHighScore", score);
        }

        SceneManager.LoadScene("FinishNumberGuessingScene");
    }

    /*
    IEnumerator DelayDialogue(int secs)
    {
        yield return new WaitForSeconds(secs);
        warningImage.gameObject.SetActive(false);
        timerIsRunning = true;
    }
    */
}
