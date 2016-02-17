using UnityEngine;
using System.Collections;

public class CharacterCamera : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = player.GetComponent<Transform>().position;
        this.transform.rotation = player.GetComponent<Transform>().rotation;
	}
}
