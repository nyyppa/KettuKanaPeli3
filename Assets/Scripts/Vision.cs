using UnityEngine;
using System.Collections;

public class Vision : MonoBehaviour {
	public VisionPoint visionpoint;
	private GameObject g;
	private float lastTime=-500000;
	public int cd=5;
	// Use this for initialization
	protected virtual void Start () {
		if(visionpoint!=null){
			g = visionpoint.gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {


	}
	void OnTriggerStay(Collider other){
		//print (other.tag);
		if (other.tag.Equals ("Fox")) {
			RaycastHit hit=new RaycastHit();
			Physics.Linecast (transform.parent.position,other.transform.position,out hit);

			if(hit.collider.tag.Equals ("Fox")){
				//print (other.transform.position);
				if(Time.realtimeSinceStartup>lastTime+cd){
					lastTime = Time.realtimeSinceStartup;
					GameObject gameObject = (GameObject)Instantiate (g, other.transform.position, other.transform.rotation);
					gameObject.SetActive (true);
					GuardPatrol patrol = GetComponentInParent <GuardPatrol> ();
					patrol.setVisionPoint (gameObject.GetComponent <VisionPoint> ());
				}

			}

			/*Destroy(other.gameObject);*/

		}
	}
}
