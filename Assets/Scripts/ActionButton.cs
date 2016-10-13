using UnityEngine;
using System.Collections;

public class ActionButton : MonoBehaviour {
	public KeyCode UseKey=KeyCode.Space;

	void OnTriggerStay(Collider other) {
		UseStuff stuff = other.gameObject.GetComponent<UseStuff> ();
		if(stuff){
			if(Input.GetKey(UseKey)){
				stuff.UseStuffAction ();
			}
		}

	}
}
