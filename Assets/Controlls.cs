using System;
using System.Diagnostics;
using UnityEngine;

// ReSharper disable All

public class Movement : MonoBehaviour
{
    private const float launchVelocity = .5f;
    public GameObject projectile;

    private bool firstShot;

    private bool jumpDisabled;
    private bool lastShoot;

    private bool released;
    
    private Stopwatch shootStopwatch;
    private Stopwatch shootPower;

    void Start()
    {
        jumpDisabled = false;

        firstShot = true;

        released = true;

        shootStopwatch = new Stopwatch();
        shootStopwatch.Start();

        shootPower = new Stopwatch();
    }

    void Update()
    {
        handleMovement();
        handleShooting();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") && jumpDisabled)
        {
            jumpDisabled = false;
        }
    }

    private void handleMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * .05f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.right * -.05f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.forward * -.05f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * .05f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, .5f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down, .5f);
        }

        if (Input.GetKey(KeyCode.Space) && !jumpDisabled)
        {
            transform.position += transform.up * .1f;
        }

        if (transform.position.y > 1.5f)
        {
            jumpDisabled = true;
        }
    }

    private void handleShooting()
    {
        if (Input.GetKey(KeyCode.F) && released && (firstShot || shootStopwatch.ElapsedMilliseconds > 500) &&
            shootPower.ElapsedMilliseconds < 1000)
        {
            if (!lastShoot)
            {
                shootPower.Start();
                lastShoot = true;
            }
        }
        else if (lastShoot && shootPower.ElapsedMilliseconds > 500)
        {
            GameObject projectileObject = Instantiate(projectile,
                new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z),
                Quaternion.Euler(0 , 0, 0)
            );
            
            projectileObject.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * launchVelocity * shootPower.ElapsedMilliseconds);

            shootStopwatch.Restart();
            shootPower.Reset();
            
            if (firstShot)
            {
                firstShot = false;
            }

            lastShoot = false;
            released = false;
        }

        if (!Input.GetKey(KeyCode.F))
        {
            released = true;
        }
    }
}