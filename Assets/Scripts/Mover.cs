using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    
    public float speed ;
    
    // Use this for initialization
    void Update () {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
    }

    public void Move(Vector3 move)
    {
        transform.Translate(move * speed * Time.deltaTime, Space.World);
    }
}
