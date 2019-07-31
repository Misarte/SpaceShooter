using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverAsteroids : MonoBehaviour {
    public float speed;
    private float delay;
    //public float fireRate;

    void Start()
    {
       // InvokeRepeating("MoveFast", delay, fireRate);//enemy fires in waves
    }

    //void MoveFast()
    //{
    //    speed = speed * 3;
    //    transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
    //}
    // Use this for initialization
    void Update()
    {
        //fireRate = Random.Range(0,10);
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
    }
}
