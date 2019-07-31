using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDiagLeft : MonoBehaviour
{

    public float speed;
    private Vector3 v3;

    // Use this for initialization
    void Update()
    {

        v3 = Vector3.back + Vector3.right;
        transform.Translate(v3 * speed * Time.deltaTime, Space.World);
    }
}