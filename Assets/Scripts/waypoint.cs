using UnityEngine;
using System.Collections;

public class waypoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		//print (other.tag);
		if (other.tag.Equals ("Guard")) {
			GuardPatrol gp = other.GetComponent<GuardPatrol> ();
			if(gp!=null){
				gp.waypointReached (this);
			}
		}

	}
}
