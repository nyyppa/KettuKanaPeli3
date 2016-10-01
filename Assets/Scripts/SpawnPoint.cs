using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {
	static SpawnPoint spawnPoint;
	public GameObject guard;
	static GameObject Guard;
	// Use this for initialization
	void Start () {
		spawnPoint = this;
		Guard = guard;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public static void SpawnGuard(){
		GameObject gameObject = (GameObject)Instantiate (Guard, spawnPoint.transform.position, spawnPoint.transform.rotation);
	}
}
