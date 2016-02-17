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
        Quaternion dRotation = Quaternion.Euler(new Vector3(0, Input.GetAxis("Horizontal") / 2, 0));
        rb.MoveRotation(rb.rotation * dRotation);
        //Debug.Log(this.transform.rotation);
		rb.velocity = transform.forward * 3;
        //Debug.Log(rb.rotation);
	}
    void OnTriggerEnter (Collider O)
    {
        Debug.Log("You have hit an object.");
    }
}
