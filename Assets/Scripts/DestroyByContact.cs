using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    public GameController gameController;
    public int scoreValueAsteroids = 1;
    public int scoreValue = 10;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")//ignore this gameobject
        {
            return;
        }
        if (other.tag == "Asteroid")//ignore this gameobject
        {
            return;
        }
        
        if (other.tag == "Player")//ignore this gameobject
        {
            GameObject explodePlayer = Instantiate(playerExplosion, transform.position, transform.rotation) as GameObject;
            gameController.GameOver();//activate gameOver Panel
        }
        GameObject explode =  Instantiate(explosion, transform.position, transform.rotation) as GameObject;
        gameController.AddScoreAsteroids(scoreValueAsteroids);
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
