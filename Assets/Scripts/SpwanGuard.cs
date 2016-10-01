using UnityEngine;
using System.Collections;

public class SpwanGuard : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnDisable(){
		SpawnPoint.SpawnGuard ();
	}
}
