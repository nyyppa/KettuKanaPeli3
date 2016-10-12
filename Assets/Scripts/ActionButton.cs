using UnityEngine;
using System.Collections;

public class ActionButton : MonoBehaviour {
	public KeyCode UseKey=KeyCode.Space;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) {
		UseStuff stuff = other.gameObject.GetComponent<UseStuff> ();
		if(stuff){
			if(Input.GetKey(UseKey)){
				stuff.UseStuffAction ();
			}
		}

	}
}
