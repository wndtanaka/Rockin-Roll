﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

{ 
    public void PlayButton()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void HallOfFameButton()
    {
        SceneManager.LoadScene("Mobile");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
