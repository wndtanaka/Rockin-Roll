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
        if (isDead)
        {
            gameOverMenu.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            isPaused = !isPaused;
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
        pauseMenu.SetActive(false);
        StartCoroutine(ResumeGame());
        //pauseMenu.SetActive(false);
        //Time.timeScale = 1;
        //isPaused = !isPaused;
    }

    public IEnumerator ResumeGame()
    {
        waitCounter = 3;
        while (waitCounter > 0f)
        {
            counterText.gameObject.SetActive(true);
            counterText.text = waitCounter.ToString("F0");
            waitCounter -= Time.unscaledDeltaTime;
            yield return null;
        }
        Time.timeScale = 1;
        counterText.gameObject.SetActive(false);
    }
}
