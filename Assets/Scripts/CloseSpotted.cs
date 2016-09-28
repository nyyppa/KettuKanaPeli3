using UnityEngine;
using System.Collections;

public class CloseSpotted : MonoBehaviour {
	float lastSpot;
	public float followTime=1;
	GuardPatrol guard;
	GameObject player;
	// Use this for initialization
	void Start () {
		guard = GetComponentInParent<GuardPatrol> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time<lastSpot+followTime){
			guard.followPlayer (player);
		}else{
			guard.followPlayer (null);
		}
	}
	void setFollow(Collider collider){
		if(collider.tag.Equals ("Fox")){
			RaycastHit hit=new RaycastHit();
			Physics.Linecast (transform.root.position,collider.transform.position,out hit);

			if (hit.collider.tag.Equals ("Fox")) {

				lastSpot = Time.time;
				player = collider.gameObject;
			}

		}
	}
	void OnTriggerEnter(Collider collider){
		setFollow (collider);

	}
	void OnTriggerStay(Collider collider){
		
		setFollow (collider);
	}
}
