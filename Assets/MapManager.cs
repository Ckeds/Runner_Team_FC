using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MapManager : MonoBehaviour {
	public GameObject map;
	public GameObject player;
	float size = 100;
	List<Vector2> mapPos;
	// Use this for initialization
	void Start () {
		mapPos = new List<Vector2>();
		GameObject g = (GameObject)Instantiate(map, new Vector3(0,0,0), Quaternion.identity);
		g.GetComponent<RandomGeneration>().difficulty = Random.Range(5,15);
		g.GetComponent<RandomGeneration>().player = this.player;
		g.GetComponent<RandomGeneration>().Create(0, 0);
		mapPos.Add(new Vector2(0,0));
	}

    // Update is called once per frame
    void Update () {
		//finds current block you are standing on
		float closest = 10000;
		Vector2 close = new Vector2(0,0);
		Debug.Log(mapPos.Count);
		for(int v = mapPos.Count - 1; v >= 0; v--)
		{
			Debug.Log("here");
			float distance = (player.transform.position.x - mapPos[v].x) * (player.transform.position.x - mapPos[v].x);
			distance += (player.transform.position.z - mapPos[v].y) * (player.transform.position.z - mapPos[v].y);
			distance = Mathf.Sqrt(distance);
			if(5 * distance / 4 > this.size)
			{
				mapPos.RemoveAt(v);
			}
			if(distance < closest)
			{
				close = mapPos[v];
				closest = distance;
			}
		}
		//searches to see if a new map is needed
		for(int i = -1; i <= 1; i++){
			for(int j = -1; j <= 1; j++){
				bool exists = false;
				Vector2 vec = close + new Vector2(size * i, size * j);
				float d = (player.transform.position.x - vec.x) * (player.transform.position.x - vec.x);
				d += (player.transform.position.z - vec.y) * (player.transform.position.z - vec.y);
				d = Mathf.Sqrt(d);
				//are we in range
				if(5 * d / 4 < this.size){
					//Debug.Log("here");
					//does this spot already exist
					foreach (Vector2 v in mapPos){
						//Debug.Log(v);
						//Debug.Log(vec);
						if(vec == v){
							exists = true;
							Debug.Log("YES");
							break;
						}
					}
					//if not, create
					if (exists == false){
						GameObject g = (GameObject)Instantiate(map, new Vector3(0,0,0), Quaternion.identity);
						g.GetComponent<RandomGeneration>().difficulty = Random.Range(5,15);
						g.GetComponent<RandomGeneration>().player = this.player;
						g.GetComponent<RandomGeneration>().Create(vec.x, vec.y);
						mapPos.Add(vec);
					}
				}
			}
		}
	}
}
