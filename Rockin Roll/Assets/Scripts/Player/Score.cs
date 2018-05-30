using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public UIManager uiManager;

    // Actual Score Calculator
    public static float playerScore;

    public float inputWaitTimer;

    // Current Score to show Player on UI
    public float showScore;

    public float inputMinimum;

    // High Score
    public float highScore;

    // Use this for initialization
    void Start()
    {
        playerScore = 0f;

        inputWaitTimer = 0f;

        inputMinimum = 0.2f;

        // If "HighScore" doesn't exist, this sets Default to 0
        highScore = PlayerPrefs.GetFloat("HighScore", 0);

        Debug.Log("High Score is " + highScore);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("showScore = " + showScore);

        Scoring();

        showScore = Mathf.Floor(playerScore);

        HighScoreCheck();
    }

    void Scoring()
    {
        if ((Input.GetKey(KeyCode.Space)) && UIManager.isDead != true && uiManager.isPaused != true)
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
        if (UIManager.isDead == true)
        {
            if (highScore < showScore )
            {
                PlayerPrefs.SetFloat("HighScore", showScore);

                Debug.Log("New High Score is " + PlayerPrefs.GetFloat("HighScore"));
            }
        }
    }
}
