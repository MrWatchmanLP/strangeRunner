using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public static float speed;
    public static bool isUp = false;
    public float highscore;
    public float step;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.forward;
    }

    void Update()
    {
        //increase speed
        speed = transform.position.z * step;
        rb.velocity = Vector3.forward * speed;
        if(Input.GetMouseButtonDown(0) && isUp == false)
        {
            rb.velocity += Vector3.up * speed;
            //some git shit
        }
        else
        {
            rb.velocity -= Vector3.up * speed;
        }
    }
}
