using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject pauseMenu;
    public Text counterText;
    // both from Game Over gameobject
    public Text yourScore;
    public Text highScore;

    public static bool isDead = false;
    public static bool isPaused = false;

    float waitCounter = 3;

    Score score;

    public static event OnUpdateHighScore onUpdateHighScore;

    private void Start()
    {
        score = GetComponent<Score>();
        isDead = false;
    }

    private void Update()
    {
        if (isPaused)
        {
            GameManager.Instance.InputController.enabled = false;
        }
        if (isDead)
        {
            onUpdateHighScore.Invoke();
            score.scoreboard.gameObject.SetActive(false);
            score.highScoreBoard.gameObject.SetActive(false);
            gameOverMenu.SetActive(true);
            yourScore.text = "Your Score: " + score.showScore.ToString();
            highScore.text = "High Score: " + score.highScore.ToString();
        }
        if (GameManager.Instance.InputController.Pause && !isPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            isPaused = !isPaused;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            StartCoroutine(ResumeGame());
        }
    }

    public void PlayAgainButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenuButton()
    {
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
    }
}
