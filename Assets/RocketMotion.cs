using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMotion : MonoBehaviour
{
    public Rigidbody rb;
    private bool moveLeft = false;
    private bool moveUp = false;
    private bool moveDown = false;
    private bool moveRight = false;
    public float sideForce = 500f;
    public float upForce = 500f;
    public float downForce = 500f;
    private string[] keys = { "a", "d", "s", "w" };
    void Update()
    {
        if (Input.GetKey(keys[0]))
        {
            Debug.Log("a pressed");
            moveRight = true;
        }
        else if (Input.GetKey(keys[1]))
        {
            moveLeft = true;
        }
        else if (Input.GetKey(keys[2]))
        {
            moveUp = true;
        }
        else if (Input.GetKey(keys[3]))
        {
            moveDown = true;
        }
        else
        {
            moveLeft = false;
            moveRight = false;
            moveDown = false;
            moveUp = false;
        }
    }
    void FixedUpdate()
    {
        //rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if (moveLeft)
        {
            rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        else if (moveRight)
        {
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        else if (moveUp)
        {
            rb.AddForce(0, -upForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }
        else if (moveDown)
        {
            rb.AddForce(0, downForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }

        //if (rb.position.y < -1f)
        //{
        //    FindObjectOfType<GameManager>().EndGame();
        //}
    }
}
