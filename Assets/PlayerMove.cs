﻿using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
    Rigidbody rb;
	float speed;
	float speedRegular = 8;
	float speedSlowed = 2;
	float maxX;
	float maxY;
	float minX;
	float minY;
	public bool gameOver = false;
	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody>();
		speed = speedRegular;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(Cursor.lockState);
        Quaternion dRotation = Quaternion.Euler( new Vector3( 0, Input.GetAxis( "Mouse X" ) * 3, 0 ) );
        rb.MoveRotation( rb.rotation * dRotation );

        if( Input.GetKey( "mouse 0" ) ) {
            rb.velocity = transform.forward * speed;
        } else {
            rb.velocity = transform.forward * 0;
        }

        //Debug.Log( rb.position.x );
	}
    void OnTriggerEnter (Collider O)
    {
        Debug.Log(O);
		if (O.name == "Fire Sub(Clone)") {
			Debug.Log ("GAME OVER");
			gameOver = true;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
		speed = speedSlowed;
    }
	void OnTriggerExit (Collider O)
	{
		speed = speedRegular;
	}
	void OnCollisionEnter(Collision O)
	{

	}
}
