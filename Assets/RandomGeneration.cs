using UnityEngine;
using System.Collections;

public class RandomGeneration : MonoBehaviour {
	public GameObject RockPrefab;
	public GameObject TreePrefab;
	public int numObstacles;
	public float maxDistance;

	// Use this for initialization
	void Start () {
		for (var i = 0; i < numObstacles; i++){
			float tempZ = Random.Range(10,maxDistance);
			float tempX = Random.Range(0, tempZ * 2) - tempZ;
			int obstaclePick = (int) Mathf.Floor(Random.Range(0,2));
			Vector3 position;
			switch(obstaclePick){
				case 0:
					position = new Vector3(tempX, 0 ,tempZ);
					Instantiate(RockPrefab, position, Quaternion.identity);
					break;
				case 1:
					position = new Vector3(tempX, 0 ,tempZ);
					Instantiate(TreePrefab, position, Quaternion.identity);
					break;
				default:
					position = new Vector3(tempX, 0 ,tempZ);
					Instantiate(RockPrefab, position, Quaternion.identity);
					break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
