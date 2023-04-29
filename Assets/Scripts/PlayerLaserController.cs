using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserController : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject laserHit;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            transform.position.x + speed * Time.deltaTime, 
            transform.position.y,
            transform.position.z
            );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        Instantiate( laserHit, transform.position, transform.rotation );
        Destroy( gameObject );
        if (other.tag == "Enemy" || other.tag == "Asteroid") { Destroy(other.gameObject); }
        

    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
