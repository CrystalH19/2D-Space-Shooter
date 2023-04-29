using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject laserShot;
    public Transform firePoint;
    public float shotDelay = 0.4f;
    float shotTimer;
    public float delay = 5f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            autoShot();
    }

    public void autoShot()
    {
        shotTimer -= Time.deltaTime;
        if (shotTimer <= 0)
        {
            Instantiate(laserShot, firePoint.position, firePoint.rotation);
            
            shotTimer = shotDelay;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
