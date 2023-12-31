using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;
    public System.Action destroyed;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    private void Update()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        this.destroyed.Invoke();
        Destroy(this.gameObject);
    }
}
