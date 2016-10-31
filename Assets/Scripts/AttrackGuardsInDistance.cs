using UnityEngine;
using System.Collections;

public class AttrackGuardsInDistance : MonoBehaviour {
	Vector3 center;
	float radius;
	// Use this for initialization
	void Start () {
		SphereCollider sphere = GetComponent<SphereCollider> ();
		center = sphere.center;
		radius = sphere.radius;
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.isEditor){
			SphereCollider sphere = GetComponent<SphereCollider> ();
			center = sphere.center;
			radius = sphere.radius;
		}
			
	}

	public void callGuards(){
		Collider[] hitColliders = Physics.OverlapSphere(center, radius);
		for(int i=0;i<hitColliders.Length;i++){
			if (hitColliders[i].tag.Equals("Guard")) {
				Vision v = hitColliders [i].gameObject.GetComponentInChildren<Vision> ();
				if (v) {
					Transform t = new GameObject ().transform;
					t.position = transform.position + new Vector3 (1, 0, 1);
					v.setVisionPoint (t);
					Destroy (t.gameObject);
				}
			}
		}
	}
}
