using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MapManager : MonoBehaviour {
	public GameObject player;
	ResourceManager rm;
	float size = 25;
	List<Vector2> mapPos;
	// Use this for initialization
	void Start () {
		rm = GetComponent<ResourceManager>();
		rm.Setup(9,50,50);
		mapPos = new List<Vector2>();
		GameObject g = rm.GetMap();
		g.GetComponent<RandomGeneration>().difficulty = Random.Range(5,15);
		g.GetComponent<RandomGeneration>().player = this.player;
		g.GetComponent<RandomGeneration>().Create(0, 0, rm);
		g.SetActive(true);
		mapPos.Add(new Vector2(0,0));
	}

    // Update is called once per frame
    void Update () {
		//finds current block you are standing on
		float closest = 10000;
		Vector2 close = new Vector2(0,0);
		//Debug.Log(mapPos.Count);
		for(int v = mapPos.Count - 1; v >= 0; v--)
		{
			float distance = (player.transform.position.x - mapPos[v].x) * (player.transform.position.x - mapPos[v].x);
			distance += (player.transform.position.z - mapPos[v].y) * (player.transform.position.z - mapPos[v].y);
			distance = Mathf.Sqrt(distance);
			if(distance < closest)
			{
				close = mapPos[v];
				closest = distance;
			}
			if(2 * distance / 4 > this.size)
			{
				mapPos.RemoveAt(v);
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
				if(2 * d / 4 < this.size){

					//does this spot already exist
					foreach (Vector2 v in mapPos){

						if(vec == v){
							exists = true;
							break;
						}
					}
					//if not, create
					if (exists == false){
						GameObject g = rm.GetMap();
						g.GetComponent<RandomGeneration>().difficulty = Random.Range(5,15);
                        g.GetComponent<RandomGeneration>().size = this.size;
                        g.GetComponent<RandomGeneration>().player = this.player;
						g.GetComponent<RandomGeneration>().Create(vec.x, vec.y, rm);
						g.SetActive(true);
						mapPos.Add(vec);
					}
				}
			}
		}
	}
}
