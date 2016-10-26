using UnityEngine;
using System.Collections;

public class ActionButton : MonoBehaviour {
	public KeyCode UseKey=KeyCode.Space;
    Animator _animator;
    bool isBiting = false;

    void Start()
    {
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
            isBiting = true;
            _animator.SetBool("isBiting", isBiting);
            isBiting = false;
        }
    }
}
