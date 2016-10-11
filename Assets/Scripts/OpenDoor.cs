using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {
	public GameObject lockedDoor;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision other){
		if(other.collider.tag.Equals ("Fox")){
			if(lockedDoor){
				lockedDoor.SetActive (false);
			}
			gameObject.SetActive (false);
		}
	}

}
