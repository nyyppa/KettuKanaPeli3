using UnityEngine;
using System.Collections;

public class SpawnGuard : MonoBehaviour {

	void OnDisable(){
		if(this.enabled){
			SpawnPoint.SpawnGuard ();
		}

	}
}
