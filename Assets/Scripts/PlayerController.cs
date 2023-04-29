using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    public float speed = 8.0f;
    public Transform upperLeftBound, lowerRightBound;

    Animator anim;
    public GameObject laserShot;
    public Transform firePoint;
    public float shotDelay = 0.4f;
    float shotTimer;
    GameController controller;


    void Start()
    {
        controller = GetComponent<GameController>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = moveInput * speed;
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, upperLeftBound.position.x, lowerRightBound.position.x),
            Mathf.Clamp(transform.position.y, lowerRightBound.position.y, upperLeftBound.position.y),
            transform.position.z
            );

        anim.SetFloat("PlayerMovement", Input.GetAxisRaw("Vertical"));

        if (Input.GetButtonDown("Fire1")) {
            Instantiate(laserShot, firePoint.position, firePoint.rotation);
        }

        if (Input.GetButton("Fire1"))
        {
            shotTimer -= Time.deltaTime;
            if (shotTimer <= 0)
            {
                Instantiate(laserShot, firePoint.position, firePoint.rotation);
                shotTimer = shotDelay;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "Asteroid" || other.tag == "Laser")
        {
            controller.LoseLife();
            Debug.Log(other.tag);
        }
        //if tag = anything that can cause damage, then gamecontroller.loselife()

    }

}
