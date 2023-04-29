using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject laserHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            transform.position.x + -speed * Time.deltaTime,
            transform.position.y,
            transform.position.z
            );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);

        Destroy(gameObject);
        //Instantiate( laserHit, transform.position, transform.rotation );
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
