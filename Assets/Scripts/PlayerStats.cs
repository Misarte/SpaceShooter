using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int Points; //accessible using only PlayerStats type without requiring reference of any particular object, carries on from one scene to another
   
    public static int Asteroids;

    
    public int startPoints = 0; //can edit from inspector


    void Start()
    {
        Points = startPoints;

        Asteroids = 0;
    }
}
