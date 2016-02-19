using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomGeneration : MonoBehaviour {
	public GameObject RockPrefab;
	public GameObject TreePrefab;
	public float difficulty;
	public float size;
	public GameObject player;
	float x;
	float y;
	List<GameObject> obstacles;
	// Use this for initialization
	void Start () {}

	public void Create (float x, float y) {
		obstacles = new List<GameObject>();
		this.x = x;
		this.y = y;
		float tempZ;
		float tempX;
		for (var i = 0; i < (int)(difficulty * 5); i++){
			GameObject g = null;
			do{
				tempZ = Random.Range(-size / 2,size / 2);
			}while(Mathf.Abs(player.transform.position.z - tempZ) < 2);
			do{
				tempX = Random.Range(-size / 2,size / 2);
			}while(Mathf.Abs(player.transform.position.x - tempX) < 2);
			int obstaclePick = (int) Mathf.Floor(Random.Range(0,2));
			Vector3 position;
			switch(obstaclePick){
			case 0:
				position = new Vector3(tempX + x, 0 ,tempZ + y);
				g = (GameObject)Instantiate(RockPrefab, position, Quaternion.identity);
				Debug.Log(g);
				obstacles.Add(g);
				break;
			case 1:
				position = new Vector3(tempX + x, 0 ,tempZ + y);
				g = (GameObject)Instantiate(TreePrefab, position, Quaternion.identity);
				Debug.Log(g);
				obstacles.Add(g);
				break;
			default:
				position = new Vector3(tempX + x, 0 ,tempZ + y);
				g = (GameObject)Instantiate(RockPrefab, position, Quaternion.identity);
				obstacles.Add(g);
				break;
			}
		}
	}
	// Update is called once per frame
	void Update () {
		float distance = (player.transform.position.x - this.x) * (player.transform.position.x - this.x);
		distance += (player.transform.position.z - this.y) * (player.transform.position.z - this.y);
		distance = Mathf.Sqrt(distance);
		Debug.Log(distance);
		if(2 * distance / 4 > this.size)
		{
			foreach (GameObject g in obstacles){
				Destroy(g);
			}
			Destroy(transform.root.gameObject);
		}
	}
}
