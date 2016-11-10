using UnityEngine;
using System.Collections;

namespace Kettukanapeli
{
    public class PuppyAI : MonoBehaviour
    {
        Animator _animator;

        void Start()
        {
            _animator = GetComponent<Animator>();
        }

        void Walk()
        {
            _animator.SetBool("isRunning", true);
        }
    }
}