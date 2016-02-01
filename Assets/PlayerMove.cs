using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = this.transform.position;
		position.z += .05f;
		position.x += Input.GetAxis ("Horizontal") / 20;
		this.transform.position = position;
		//Debug.Log(this.transform.rotation);
		this.transform.rotation = Quaternion.identity;
		this.GetComponent<Rigidbody> ().velocity = Vector3.zero;
	}
}
