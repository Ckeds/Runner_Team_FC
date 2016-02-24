using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Color color = GetComponent<MeshRenderer>().material.color;
		color.r = 255.0f;
		color.b = 0.0f;
		color.g = 0.0f;
		color.a = 0.5f;
		GetComponent<MeshRenderer>().material.color = color;

		float x = this.transform.localScale.x + 0.05f;
		float z = this.transform.localScale.z + 0.05f;

		this.transform.localScale = new Vector3(x,4,z);
	}
}
