using UnityEngine;
using System.Collections;

public class OpenDoor : UseStuff {
	public GameObject lockedDoor;

	public override void UseStuffAction(){
		if(lockedDoor){
			lockedDoor.SetActive (false);
		}

		gameObject.SetActive (false);
	}
}
