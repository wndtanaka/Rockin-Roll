using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    // Actual Score Calculator
    public static float playerScore;

    public float inputWaitTimer;

    // Current Score to show Player on UI
    public float showScore;
    public int showScoreInt;

    public float inputMinimum;

    // High Score
    public int highScore;

    public Text scoreboard;
    public Text highScoreBoard;

    public event OnUpdateHighScore onUpdateHighScore;

    // Use this for initialization
    void Start()
    {
        playerScore = 0f;
        inputWaitTimer = 0f;
        inputMinimum = 0.2f;

        // If "HighScore" doesn't exist, this sets Default to 0
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        UIManager.onUpdateHighScore += HighScoreCheck;

        //Debug.Log("High Score is " + highScore);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("showScore = " + showScore);

        Scoring();

        showScore = Mathf.Round(playerScore * 10f) / 10f * 10f;
        showScoreInt = (int)(showScore);

        //Debug.Log(showScoreInt);

        //HighScoreCheck();
        scoreboard.text = "Score: " + showScore.ToString();
        highScoreBoard.text = "High Score: " + highScore.ToString();

        if (Input.GetKeyDown(KeyCode.F1))
        {
            PlayerPrefs.SetInt("HighScore", 0);
            PlayerPrefs.GetInt("HighScore");
        }
    }

    void Scoring()
    {
        if (GameManager.Instance.InputController.Move && UIManager.isDead != true && UIManager.isPaused != true)
        {
            inputWaitTimer = inputWaitTimer + 1 * Time.deltaTime;

            if (inputWaitTimer >= inputMinimum)
            {
                playerScore = playerScore + 1 * Time.deltaTime;
            }
        }

        else
        {
            inputWaitTimer = 0f;
        }
    }

    void HighScoreCheck()
    {
        if (highScore < showScore)
        {
            PlayerPrefs.SetInt("HighScore", showScoreInt);

            //Debug.Log("New High Score is " + PlayerPrefs.GetFloat("HighScore"));
        }
    }
}