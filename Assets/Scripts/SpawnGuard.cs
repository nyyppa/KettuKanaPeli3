using UnityEngine;
using System.Collections;

public class SpawnGuard : MonoBehaviour {

	void OnDisable(){
		SpawnPoint.SpawnGuard ();
	}
}
