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

    public static bool isDead = false;
    private bool isPaused = false;

    float waitCounter = 3;

    private void Start()
    {
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
            gameOverMenu.SetActive(true);
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
