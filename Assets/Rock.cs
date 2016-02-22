using UnityEngine;
using System.Collections;

public class Rock : Obstacle {
	public GameObject playerReference;
	public float maximumDistanceSetActive; // This should be 
	public float minimumDistanceAtFullVisability;

	// Use this for initialization
	void Start () {
		//this.GetComponent<Renderer>().material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
        // TODO: This kills framerate, needs to cut the amount of checks done per frame
        /*
		float dist = Vector3.Distance(playerReference.transform.position,this.transform.position);
		if (dist < maximumDistanceSetActive){
			if(dist >= minimumDistanceAtFullVisability){
				//print(dist);
				Color color = this.GetComponent<Renderer>().material.color;
				color.a = MapInterval(dist,minimumDistanceAtFullVisability,maximumDistanceSetActive,1.0f,0.0f);
				//print(color.a);
				this.GetComponent<Renderer>().material.color = color;
			}
		}
		/*

        //Monday Code
        /*
        Color color = GetComponent<MeshRenderer>().material.color;
        color.a = .05f;
        GetComponent<MeshRenderer>().material.color = color;
        */
        
    }

	float MapInterval(float val, float srcMin, float srcMax, float dstMin, float dstMax) {
		if (val>=srcMax) return dstMax;
		if (val<=srcMin) return dstMin;
		return dstMin + (val-srcMin) / (srcMax-srcMin) * (dstMax-dstMin);
	}
}
