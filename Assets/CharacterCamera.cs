using UnityEngine;
using System.Collections;

public class CharacterCamera : MonoBehaviour {
	public GameObject player;
	Transform m_player;
	// Use this for initialization
	void Start () {
		m_player = player.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 prevTrans = this.transform.position;
		Vector3 currentTrans = m_player.position;
		if(prevTrans.x != currentTrans.x || prevTrans.z != currentTrans.z )
			this.transform.position = currentTrans + new Vector3(0,0.25f + Mathf.Sin(Time.time * 16) /48, 0);
		else {
			currentTrans.y += .25f;
			this.transform.position = currentTrans;
		}
		this.transform.rotation = m_player.rotation;
	}
}
