﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject gameOverMenu;
    public GameObject pauseMenu;
    public GameObject[] howToPlayPage;
    public Text counterText;
    // both from Game Over gameobject
    public Text yourScore;
    public Text highScore;
    public Text notify;
    public InputField username;
    public GameObject dummyGameObjects;

    public static bool isGameStart = false;
    public static bool isDead = false;
    public static bool isPaused = false;
    public static bool isAlive = false;

    string[] alphabets = new string[] {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
"q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};
    float waitCounter = 3;
    Score score;

    public static event OnUpdateHighScore onUpdateHighScore;

    private void Start()
    {
        score = GetComponent<Score>();
        isDead = false;
        isAlive = false;
    }

    private void Update()
    {
        if (!isGameStart && Input.GetKeyDown(KeyCode.Space))
        {
            playerPrefab.SetActive(true);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            isAlive = true;
            score.scoreboard.gameObject.SetActive(true);
            score.highScoreBoard.gameObject.SetActive(true);
            isGameStart = true;
            score.scoreboard.gameObject.SetActive(true);
            score.highScoreBoard.gameObject.SetActive(true);
            dummyGameObjects.SetActive(false);
            for (int i = 0; i < howToPlayPage.Length; i++)
            {
                howToPlayPage[i].SetActive(false);
            }

        }
        if (isPaused)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            GameManager.Instance.InputController.enabled = false;
            score.scoreboard.gameObject.SetActive(false);
            score.highScoreBoard.gameObject.SetActive(false);
        }
        if (isDead)
        {
            isGameStart = false;
            onUpdateHighScore.Invoke();
            score.scoreboard.gameObject.SetActive(false);
            score.highScoreBoard.gameObject.SetActive(false);
            gameOverMenu.SetActive(true);
            yourScore.text = "Your Score: " + score.showScore.ToString();
            highScore.text = "High Score: " + score.highScore.ToString();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (GameManager.Instance.InputController.Pause && !isPaused && isGameStart)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            isPaused = !isPaused;
            return;
        }
        //if (GameManager.Instance.InputController.Pause && isPaused)
        //{
        //    Cursor.visible = false;
        //    Cursor.lockState = CursorLockMode.Locked;
        //    StartCoroutine(ResumeGame());
        //}
    }

    public void PlayAgainButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenuButton()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            GameManager.Instance.InputController.enabled = true;
            isPaused = !isPaused;
            isGameStart = !isGameStart;
        }

        SceneManager.LoadScene("MainMenu");
    }

    public void ResumeButton()
    {
        StartCoroutine(ResumeGame());
    }

    public IEnumerator ResumeGame()
    {
        pauseMenu.SetActive(false);
        waitCounter = 3;
        while (waitCounter > 0f)
        {
            counterText.gameObject.SetActive(true);
            counterText.text = waitCounter.ToString("F0");
            waitCounter -= Time.unscaledDeltaTime;
            yield return null;
        }
        Time.timeScale = 1;
        GameManager.Instance.InputController.enabled = true;
        isPaused = !isPaused;
        counterText.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        score.scoreboard.gameObject.SetActive(true);
        score.highScoreBoard.gameObject.SetActive(true);
    }

    public void SubmitScoreButton()
    {
        if (username.text == "" || username.text.Contains(" ") || username.text.Contains(".") || username.text.Contains(","))
        {
            Debug.Log(username.text);
            notify.text = "Proper username please";
            StartCoroutine(Notification());
        }
        else
        {
            SubmitHighScore.AddNewHighScore(username.text, score.showScoreInt);
        }
    }

    IEnumerator Notification()
    {
        notify.enabled = true;
        yield return new WaitForSeconds(2f);
        notify.enabled = false;
    }

    public void Page1RightButton()
    {
        howToPlayPage[0].SetActive(false);
        howToPlayPage[1].SetActive(true);
    }
    public void Page2LeftButton()
    {
        howToPlayPage[1].SetActive(false);
        howToPlayPage[0].SetActive(true);
    }
    public void Page2RightButton()
    {
        howToPlayPage[1].SetActive(false);
        howToPlayPage[2].SetActive(true);
    }
    public void Page3LeftButton()
    {
        howToPlayPage[2].SetActive(false);
        howToPlayPage[1].SetActive(true);
    }
}
