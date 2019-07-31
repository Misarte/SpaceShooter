﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour {
    public string level2 = "Level2";
    public string level1 = "Main";

    public void Retry()
    {
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            SceneManager.LoadScene(level1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //to reload the scene correctly when hit on Retry Button
        }
    }
    public void Next()
    {
        SceneManager.LoadScene(level2); //to reload the scene correctly when hit on Retry Button
    }
    public void Quit()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }
}