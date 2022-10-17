using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Highscore : MonoBehaviour
{
    /*
    public TextMeshPro numberTypingHighscore;
    public TextMeshPro numberTypingScore;
    public TextMeshPro alphabetTypingHighscore;
    public TextMeshPro alphabetTypingScore;

    public TextMeshPro numberGuessingHighscore;
    public TextMeshPro numberGuessingScore;
    public TextMeshPro alphabetGuessingHighscore;
    public TextMeshPro alphabetGuessingScore;
    */
    public TextMeshPro playerScore;
    public TextMeshPro playerHighscore;


    // Start is called before the first frame update
    void Start()
    {
        ScoreToShow();
    }
    public void ScoreToShow()
    {
        if (PlayerPrefs.GetString("PlayerScore") == "Alphabet_Typing")
        {
            playerScore.text = "Skor anda : " + PlayerPrefs.GetInt("AlphabetTypingScore");
            playerHighscore.text = "Highscore : " + PlayerPrefs.GetInt("AlphabetTypingHighScore");
        }

        else if (PlayerPrefs.GetString("PlayerScore") == "Number_Typing")
        {
            playerScore.text = "Skor anda : " + PlayerPrefs.GetInt("NumberTypingScore");
            playerHighscore.text = "Highscore : " + PlayerPrefs.GetInt("NumberTypingHighScore");
        }

        else if (PlayerPrefs.GetString("PlayerScore") == "Alphabet_Guessing")
        {

            playerScore.text = "Skor anda : " + PlayerPrefs.GetInt("AlphabetGuessingScore");
            playerHighscore.text = "Highscore : " + PlayerPrefs.GetInt("AlphabetGuessingHighScore");
        }

        else if (PlayerPrefs.GetString("PlayerScore") == "Number_Guessing")
        {
            playerScore.text = "Skor anda : " + PlayerPrefs.GetInt("NumberGuessingScore");
            playerHighscore.text = "Highscore : " + PlayerPrefs.GetInt("NumberGuessingHighScore");
        }

        /*
        numberTypingHighscore.text = "Highscore : " + PlayerPrefs.GetInt("NumberTypingHighScore");
        numberTypingScore.text = "Skor anda : " + PlayerPrefs.GetInt("NumberTypingScore");
        alphabetTypingHighscore.text = "Highscore : " + PlayerPrefs.GetInt("AlphabetTypingHighScore");
        alphabetTypingScore.text = "Skor anda : " + PlayerPrefs.GetInt("AlphabetTypingScore");
        
        numberGuessingHighscore.text = "Highscore : " + PlayerPrefs.GetInt("NumberGuessingHighScore");
        numberGuessingScore.text = "Skor anda : " + PlayerPrefs.GetInt("NumberGuessingScore");
        alphabetGuessingHighscore.text = "Highscore : " + PlayerPrefs.GetInt("AlphabetGuessingHighScore");
        alphabetGuessingScore.text = "Skor anda : " + PlayerPrefs.GetInt("AlphabetGuessingScore");
        */

    }

}
