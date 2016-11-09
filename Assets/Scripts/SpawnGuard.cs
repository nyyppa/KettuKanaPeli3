using UnityEngine;
using System.Collections;

public class SpawnGuard : MonoBehaviour {
	public SpawnPoint p;
	bool quit = false;
	void OnDisable(){
		if(!quit){
			if(p){
				p.SpawnGuard2 ();
			}else{
				SpawnPoint.SpawnGuard ();
			}

		}

	}
	void OnApplicationQuit(){
		quit = true;
	}
}
