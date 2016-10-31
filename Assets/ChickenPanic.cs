using UnityEngine;
using System.Collections;

public class ChickenPanic : MonoBehaviour {
	public float PanicTime=5;
	float timeSpendInPanic = 10;
	Animator _animator;
	// Use this for initialization
	void Start () {
		_animator = GetComponentInParent<Animator> ();
		print (_animator);
	}
	
	// Update is called once per frame
	void Update () {
		timeSpendInPanic += Time.deltaTime;
		if(timeSpendInPanic<PanicTime){
			if(_animator){
				_animator.SetBool ("IsPanicking", true);
			}
		}else{
			if(_animator){
				_animator.SetBool ("IsPanicking", false);
			}
		}
	}
	void OnTriggerEnter(Collider collider){
		if(collider.tag.Equals("Fox")){
			AttrackGuardsInDistance a = GetComponentInChildren<AttrackGuardsInDistance> ();
			panic ();
			if(a){
				a.callGuards ();
			}
		}
	}
	void OnTriggerStay(Collider collider){
		if(collider.tag.Equals("Fox")){
			AttrackGuardsInDistance a = GetComponentInChildren<AttrackGuardsInDistance> ();
			panic ();
			if(a){
				a.callGuards ();
			}
		}
	}

	void panic(){
		timeSpendInPanic = 0;
	}
}
