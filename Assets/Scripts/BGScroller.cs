using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour
{

    public float scrollSpeed;
    public float tileSizeZ;//size of background

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ-1);//repeat backgrounds position
        transform.position = startPosition + Vector3.back * newPosition;
    }
}