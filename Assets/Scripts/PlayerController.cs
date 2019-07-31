using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    [Header("Movement Attributes")]//to organize Inspector
    public float speed;
    public float rotateSpeed = 5f; 
    [HideInInspector]
    public Vector3 position;
    [HideInInspector]
    public Quaternion rotation;
    [HideInInspector]
    public float minX, maxX, minZ , maxZ;
    public float tilt;
    [Header("Shooting Attributes")]//to organize Inspector
    public GameObject bullet;
    public Transform[] shotSpawn;
    public float fireRate;
    private float nextFire;
    private AudioSource weaponSound;
    [HideInInspector]
    public Mover moveBullet;

    void Start()
    {
        GameObject limits = GameObject.Find("Background");
        moveBullet = bullet.GetComponent<Mover>();
        float sizeX = limits.transform.localScale.x;
        minX = -limits.transform.localScale.x / 2 + 1;
        maxX =  limits.transform.localScale.x / 2 - 1;
        minZ = -9;
        maxZ = 9;
        rotation = transform.rotation; //get rotation
        weaponSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        //-----------------move on Z axis-----------------------
        if ((Input.GetKey("w")) || (Input.GetKey("up"))) 
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World); //move player on the z axis, delta time so speed is independent form frame rate (different computers power wont affect speed for ex), convert to world space so rotation of camera doesnt affect movement
        }
        if ((Input.GetKey("s")) || (Input.GetKey("down"))) //no key down or key up so move every frame, if mouse is on top of the gameview
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World); //move player on the z axis, delta time so speed is independent form frame rate (different computers power wont affect speed for ex), convert to world space so rotation of camera doesnt affect movement
        }

        //--------------------move on x axis------------------------
        if ((Input.GetKey("d")) || (Input.GetKey("right"))) 
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World); //move player on the x axis, delta time so speed is independent form frame rate (different computers power wont affect speed for ex), convert to world space so rotation of camera doesnt affect movement                                                                          
            transform.rotation = rotation;
        }
        else if ((Input.GetKey("a")) || (Input.GetKey("left"))) //no key down or key up so move every frame, if mouse is on top of the gameview
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World); //move player on the x axis, delta time so speed is independent form frame rate (different computers power wont affect speed for ex), convert to world space so rotation of camera doesnt affect movement
            transform.rotation = rotation;
        }
        else
        {
            //Align(); //to bring back initial zero rotation
        }
        position = transform.position;
        rotation = transform.rotation;
        position.x = Mathf.Clamp(position.x, minX, maxX); //restrict x so it doesnt move out of boundaries
        position.z = Mathf.Clamp(position.z, minZ, maxZ); //restrict z so it doesnt move out of boundaries
        transform.position = position;

        if (Input.GetKey("space") && (Time.time > nextFire))//space key shoots accordint to fire rate given in inspector
        {
            nextFire = Time.time + fireRate;
            foreach (Transform point in shotSpawn)
            {
                GameObject fire = Instantiate(bullet, point.position, transform.rotation) as GameObject;
            }
            Vector3 dir = transform.forward;
            moveBullet.Move(dir);
            weaponSound.Play();
        }
        if (Input.GetKey("q"))
        {
            transform.Rotate(Vector3.up  * -rotateSpeed, Space.World);
        }
        if (Input.GetKey("e"))
        {
            transform.Rotate(Vector3.down  * -rotateSpeed, Space.World);
        }
    }

    void Rotate(float posX)//rotate according to direction and position on x axis
    {
        transform.rotation = Quaternion.Euler(0f, 0f, posX * speed * -tilt);
    }

    void Align()// zero rotation
    {
        transform.rotation = Quaternion.Euler(0f, transform.rotation.y, 0f);
    }
}
