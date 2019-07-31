using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePaused : MonoBehaviour {

    public GameObject thePauseUI;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) //if user presses escape or P for Pause
        {
            Toggle();
        }
	}
    public void Toggle()
    {
        thePauseUI.SetActive(!thePauseUI.activeSelf);
        if (thePauseUI.activeSelf)
        {
            Time.timeScale = 0f; //freeze time
            AudioListener.pause = true;
        }
        else
        {
            Time.timeScale = 1f; //return to original timescale
            AudioListener.pause = false;
        }
    }

    public void Retry()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //to reload the scene correctly when hit on Retry Button
    }
    public void Quit()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }
}
