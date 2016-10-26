using UnityEngine;
using System.Collections;

public class ChickenAI : MonoBehaviour {
    Animator _animator;
    bool isWalking = false;
    bool isPanicking = false;

	void Start () {
        _animator = GetComponent<Animator>();
	}
	
	void Update () {
        _animator.SetBool("IsWalking", isWalking);
        _animator.SetBool("IsPanicking", isPanicking);
	}
}
