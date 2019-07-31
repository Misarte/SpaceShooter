using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string levelToLoad = "Main";
    public GameObject instructionsPanel;
    public GameObject mainMenu;

    public void Play()
    {
        Debug.Log("Play");
        SceneManager.LoadScene(levelToLoad);
    }
    public void OpenInstructions()
    {
        mainMenu.SetActive(false);
        instructionsPanel.SetActive(true);
        
    }
    public void CloseInstructions()
    {
        instructionsPanel.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
