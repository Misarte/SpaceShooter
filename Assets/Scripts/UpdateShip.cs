using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateShip : MonoBehaviour {
    [HideInInspector]
    public GameObject currentShip;
    public GameObject newShip;
    public GameObject effect;
    [HideInInspector]
    public GameController gameController;
	// Use this for initialization
	void Start () {
        currentShip = GameObject.Find("Player");
        newShip = GetComponent<GameObject>();

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");//to access helper variable in the other script
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    public void UpdateTheShip()
    {
        Destroy(currentShip);//destroy current ship to update a new one
        Instantiate(effect, currentShip.transform.position, currentShip.transform.rotation);//spawn update effect
        Instantiate(Resources.Load("SpaceShipAttack", typeof (GameObject)), currentShip.transform.position, currentShip.transform.rotation);//spawn new ship
        gameController.updated = true;//help variable to avoid null reference
        //Destroy(effect, 1.5f);
    }
}
