using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTheo : MonoBehaviour {

    public float _jumpForce;
    public float _tailleAcroupie;
    public float _tailleDebout;

    private float _distToGround;
    private static bool _allowJump;
    private Rigidbody _rb;

	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody>();
        _distToGround = GetComponent<Collider>().bounds.extents.y;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            crouch();
        }
        if (Input.GetKeyUp(KeyCode.V))
        {
            StandUp();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            GameRules.Pause();
        }
    }


    private void jump()
    {
        if (IsGround())
        {
            _rb.AddForce(Vector3.up * _jumpForce);
        }
    }

    private void crouch()
    {
        _rb.AddForce(-Vector3.up * _jumpForce);
        transform.localScale = new Vector3(transform.localScale.x, _tailleAcroupie, transform.localScale.z);
    }
    private void StandUp()
    {
        transform.localScale = new Vector3(transform.localScale.x, _tailleDebout, transform.localScale.z);
    }
    private bool IsGround()
    {
        return Physics.Raycast(transform.position, -Vector3.up, _distToGround + 0.1f);
    }
}
