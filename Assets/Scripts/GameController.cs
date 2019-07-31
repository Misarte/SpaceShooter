using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    [Header("Enemies' Attributes")]//to organize Inspector
    public GameObject[] hazards;

    public Vector3 spawnValues;

    private int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    [Header("UI Attributes")]//to organize Inspector
    public Text scoreUI;
    public Text scoreAsteroidsUI;
    public GameObject gameOverUI;
    public GameObject winUI;
    public Button update;
    public Button nextLevel;

    [HideInInspector]
    public int score;
    [HideInInspector]
    public int scoreAst;

    public static bool gameOver;
    public static bool difficulty;
    [HideInInspector]
    public bool updated;
    [HideInInspector]
    public Scene scene;
    [HideInInspector]
    public string level2 = "Level2";
    
    [HideInInspector]
    public GameObject player;
    


    // Use this for initialization
    void Start () {
        scene = SceneManager.GetActiveScene();
        player = GameObject.FindWithTag("Player");
        hazardCount = 50;
        gameOver = false;//variable is static so if we have another scene after gameover it remains true, so we set it false on start again
        updated = false;
        difficulty = false;
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player"); //check cause initial player gets destroyed when updating the ship
        }

        if (gameOver)//soupdate doesnt execute gameover million times
            return;

        if(scene.name == "Level2"){
            if (PlayerStats.Points >= 1000) //win game after getting too much points
            {
                Win();
            }
            if ((PlayerStats.Points >= 400) && (updated == false)) //win game after getting too much points
            {
                update.gameObject.SetActive(true);//activate update ship button
            }
            if (updated == true)
            {
                update.gameObject.SetActive(false);//de-activate update ship button
            }
        }
        else
        {
            if (PlayerStats.Points >= 300) //win game after getting too much money
            {
                Win();
            }
            if ((Time.timeSinceLevelLoad >= 10) && (difficulty == false))//increase difficulty after one minute only in level 1
            {
                hazardCount += 40;
                Debug.Log(hazardCount);
                difficulty = true;
            }
            //InvokeRepeating("FastAsteroid", delay, spawnRate);//enemy fires in waves
        }
    }

    IEnumerator SpawnWaves()//spawn enemies in waves with a coroutine and delay
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                if (scene.name == "Level2")
                {
                    GameObject hazard = hazards[Random.Range(0, hazards.Length)];//pick randomly which enemy to spawn
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);//place enemies in random position on the x axis
                    Quaternion spawnRotation = Quaternion.identity;
                    spawnRotation.y = spawnRotation.y + 180;//model was rotated initially
                    Instantiate(hazard, spawnPosition, spawnRotation);
                }
                else
                {
                    GameObject hazard = hazards[0];//if we are on level 1 we dont have Alien enemies.Just spawn asteroids
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                }
               
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
    public void AddScore(int newScoreValue)//counts Score
    {
        score += newScoreValue;
        PlayerStats.Points += newScoreValue;
        UpdateScore();
    }
    public void AddScoreAsteroids(int newScoreValue)//counts Asteroids
    {
        scoreAst += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()//updates scores in UI
    {
        scoreUI.text = "Score: "+ score;
        scoreAsteroidsUI.text = "Smashed Asteroids: " + scoreAst;
    }
    public void GameOver()
    {
        gameOver = true;
        gameOverUI.SetActive(true);//display gameover UI
    }
    public void Win()
    {
        gameOver = true;
        player.SetActive(false);
        winUI.SetActive(true);//display win UI
        if (scene.name == "Level2")
        {
            nextLevel.gameObject.SetActive(false);
        }
    }
}
