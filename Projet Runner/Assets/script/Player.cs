using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody player;
    public float speed = 1.0f;
    public float jumpforce;
    public float Rspeed = 1.0f;
    private float MouseX;
    private float MouseY;
    void Start()
    {
        player = GetComponent<Rigidbody>();

    }
    void Update()
    {
        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");

    }
    void FixedUpdate()
    {
        float jump = Input.GetAxis("Jump");
        Vector3 Up = new Vector3(0, jump, 0);
        player.AddForce(Up * jumpforce, ForceMode.Impulse); //Saut


        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z))
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            player.velocity = transform.forward * speed;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            player.velocity = -transform.forward * speed;
        }

    }
}
