using UnityEngine;
using System.Collections;

public class AttrackGuards : MonoBehaviour {
	public GuardPatrol []guards;
	Rigidbody body;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(body.velocity!=new Vector3(0,0,0)){
			for(int i=0;i<guards.Length;i++){
				Vision v = guards [i].gameObject.GetComponentInChildren<Vision> ();
				if(v){
					Transform t = new GameObject ().transform;
					t.position = transform.position + new Vector3 (3, 0, 3);
					v.setVisionPoint (t);
					Destroy (t.gameObject);
				}
			}
		}
	}

}
