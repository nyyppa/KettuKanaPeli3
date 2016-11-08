using UnityEngine;
using System.Collections;

public class ActionButton : MonoBehaviour {
	public KeyCode UseKey=KeyCode.Space;
    Animator _animator;

    void Start() {
        _animator = GetComponent<Animator>();
    }

    void OnTriggerStay(Collider other) {
		UseStuff stuff = other.gameObject.GetComponent<UseStuff> ();
		if(stuff){
			if(Input.GetKey(UseKey)){
				stuff.UseStuffAction ();
			}
		}

	}

    void Update()
    {
        if (Input.GetKey(UseKey))
        {
            _animator.SetTrigger("Bite");
        }
    }
}
