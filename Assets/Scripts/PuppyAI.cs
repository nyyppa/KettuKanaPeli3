using UnityEngine;
using System.Collections;

public class PuppyAI : MonoBehaviour {
    Animator _animator;
    
	void Start () {
        _animator = GetComponent<Animator>();
    }
    
    void Update () {
	
	}

    void Walk() {
        _animator.SetBool("isRunning", true);
    }
}
