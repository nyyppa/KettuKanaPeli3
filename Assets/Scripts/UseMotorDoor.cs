using UnityEngine;
using System.Collections;

public class UseMotorDoor : MonoBehaviour {
	public int direction=1;
	DoorOpener opener;
	// Use this for initialization
	void Start () {
		opener = GetComponentInParent<DoorOpener> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider collider){
		if(collider.tag.Equals("Guard")){
			opener.Open (direction);
		}
	}
	void OnTriggerStay(Collider collider){
		if(collider.tag.Equals("Guard")){
			opener.Open (direction);
		}
	}
}
