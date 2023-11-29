using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    public GameObject powerupIndactor;
    private GameObject player;
    private Rigidbody playerRb;
    public float speed = 5.0f;
    public bool hasPowerup = false;

   
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
    }

}
