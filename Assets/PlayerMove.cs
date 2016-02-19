using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion dRotation = Quaternion.Euler( new Vector3( 0, Input.GetAxis( "Mouse X" ) * 3, 0 ) );
        rb.MoveRotation( rb.rotation * dRotation );

        if( Input.GetKey( "mouse 0" ) ) {
            rb.velocity = transform.forward * 8;
        } else {
            rb.velocity = transform.forward * 0;
        }

        Debug.Log( rb.position.x );
	}
    void OnTriggerEnter (Collider O)
    {
        Debug.Log("You have hit an object.");
    }
}
