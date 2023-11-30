using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Projectile LaserPrefab;
    public GameObject LaserSpawn;
    public GameObject powerupIndactor;
    private GameObject player;
    private Rigidbody playerRb;
    public float xRange = 15;
    public float yMin = -4.59f;
    public float yMax = -3.02f;
    public float speed = 5.0f;
    public bool hasPowerup = false;
    private bool _laserActive;

   
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Keep the player in bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.y < yMin)
        {
            transform.position = new Vector3(transform.position.x, yMin, transform.position.z);
        }
        if (transform.position.y > yMax)
        {
            transform.position = new Vector3(transform.position.x, yMax, transform.position.z);
        }


        //Get player movement
        float forwardInput = Input.GetAxis("Vertical");

        float horizontalInput = Input.GetAxis("Horizontal");

        powerupIndactor.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }
    private void Update()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;

        }
        else if (Input.GetAxis("Horizontal") > 0) 
        {
            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            this.transform.position += Vector3.up * this.speed * Time.deltaTime;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            this.transform.position += Vector3.down * this.speed * Time.deltaTime;
        }
        if (Input.GetButtonDown("Shoot"))
        {
            Shoot();
        }
        
    }
    private void Shoot()
    {
        if(!_laserActive)
        {
           Projectile projectile = Instantiate(this.LaserPrefab, LaserSpawn.transform.position, Quaternion.identity);
            projectile.destroyed += LaserDestroyed;
            _laserActive = true;
        }
       
    }
    private void LaserDestroyed()
    {
        _laserActive = false;
    }


}
