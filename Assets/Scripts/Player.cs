using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public static float speed;
    public static bool grounded = true;
    public static float score = -10;
    public float highscore;
    public float step = 50;
    public static Vector3 MyGravity;
    public static int counter = 0;
    public static bool alive = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.forward;
        Physics.gravity *= 40;
        MyGravity = Physics.gravity;
    }

    void Update()
    {
        if(alive == true)
        {
            speed = (transform.position.z / step) + 5;
            rb.velocity = Vector3.forward * speed;
            if (Input.GetMouseButtonDown(0) && grounded)
            {
                if (counter % 2 == 0)
                {
                    Physics.gravity = MyGravity * -1 * (speed / 6);
                }
                else
                {
                    Physics.gravity = MyGravity * (speed / 6);
                }
                counter++;
            }
        }
    }

    public void Die()
    {
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        alive = false;
        //gameLogic
        Debug.Log("lose");
    }
}
