using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomGeneration : MonoBehaviour {
	public float difficulty;
	public float size;
	public GameObject player;
	float x;
	float y;
    ResourceManager rm;
    List<GameObject> obstacles;
	// Use this for initialization
	void Start () {}

	public void Create (float x, float y, ResourceManager rm) {
		obstacles = new List<GameObject>();
		this.x = x;
		this.y = y;
        this.rm = rm;
		float tempZ;
		float tempX;
		for (var i = 0; i < (int)(difficulty * size / 2 ); i++){
			GameObject g = null;
			do{
				tempZ = Random.Range(-size / 1.9f,size / 1.9f);
			}while(Mathf.Abs(player.transform.position.z - tempZ) < 2);
			do{
				tempX = Random.Range(-size / 1.9f,size / 1.9f);
			}while(Mathf.Abs(player.transform.position.x - tempX) < 2);
			int obstaclePick = (int) Mathf.Floor(Random.Range(0,2));
			Vector3 position;
			switch(obstaclePick){
			case 0:
				position = new Vector3(tempX + x, 0 ,tempZ + y);
				g = rm.GetRock();
				g.transform.position = position;
				g.SetActive(true);
				obstacles.Add(g);
				break;
			case 1:
				position = new Vector3(tempX + x, 0 ,tempZ + y);
				g = rm.GetTree();
				g.transform.position = position;
				g.SetActive(true);
				obstacles.Add(g);
				break;
			default:
				position = new Vector3(tempX + x, 0 ,tempZ + y);
				g = rm.GetRock();
				g.transform.position = position;
				g.SetActive(true);
				obstacles.Add(g);
				break;
			}
		}
	}
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<PlayerMove> ().gameOver == true) {
			rm.SortDeactivated (obstacles);
			transform.root.gameObject.SetActive (false);
		} 
		else {
			float distance = (player.transform.position.x - this.x) * (player.transform.position.x - this.x);
			distance += (player.transform.position.z - this.y) * (player.transform.position.z - this.y);
			distance = Mathf.Sqrt (distance);
			//Debug.Log(distance);
			if (2 * distance / 4 > this.size) {
				rm.SortDeactivated (obstacles);

				transform.root.gameObject.SetActive (false);
			}
		}
	}
}
