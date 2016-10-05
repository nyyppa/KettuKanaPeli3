using UnityEngine;
using System.Collections;

public class AttractGuards : MonoBehaviour {
	public GuardPatrol []guards;
	Rigidbody body;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(body.velocity.x<-0.1f||body.velocity.z<-0.1f||body.velocity.x>0.1f||body.velocity.z>0.1f){
			for(int i=0;i<guards.Length;i++){
				Vision v = guards [i].gameObject.GetComponentInChildren<Vision> ();
				if(v){
					Transform t = new GameObject ().transform;
					t.position = transform.position + new Vector3 (1, 0, 1);
					v.setVisionPoint (t);
					Destroy (t.gameObject);
				}
			}
		}
	}

}
