using UnityEngine;
using System.Collections;

public class SpawnGuard : MonoBehaviour {
	bool quit = false;
	void OnDisable(){
		if(!quit){
			SpawnPoint.SpawnGuard ();
		}

	}
	void OnApplicationQuit(){
		quit = true;
	}
}
