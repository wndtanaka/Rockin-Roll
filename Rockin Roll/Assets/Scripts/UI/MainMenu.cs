using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

{ 
    public void PlayButton()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void MobileSceneButton()
    {
        SceneManager.LoadScene("Mobile");
    }
    public void HallOfFameButton()
    {
        SceneManager.LoadScene("HallOfFame");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void BackToMainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
