using UnityEngine;
using System.Collections;

public class OpenDoor : UseStuff {
	public GameObject lockedDoor;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}
	public override void UseStuffAction(){
		if(lockedDoor){
			lockedDoor.SetActive (false);
		}
		gameObject.SetActive (false);
	}
}
