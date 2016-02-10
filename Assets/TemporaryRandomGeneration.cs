using UnityEngine;
using System.Collections;

public class TemporaryRandomGeneration : MonoBehaviour {
	Random random = new Random();
	public GameObject ObstaclePrefab;
	public int numObstacles;

	// Use this for initialization
	void Start () {
		for (var i = 0; i < numObstacles; i++){
			float tempZ = Random.Range(10,100);
			float tempX = Random.Range(0, tempZ * 2) - tempZ;
			Debug.Log(tempX + " " + tempZ);
			Vector3 position = new Vector3(tempX, 0 ,tempZ);
			Instantiate(ObstaclePrefab, position, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
