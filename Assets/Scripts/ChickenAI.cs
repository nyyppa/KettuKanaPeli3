using UnityEngine;
using System.Collections;

namespace Kettukanapeli
{
    public class ChickenAI : MonoBehaviour
    {
        Animator _animator;
        bool isWalking = false;
        bool isPanicking = false;

        void Start()
        {
            _animator = GetComponent<Animator>();
        }

        void Update()
        {
            _animator.SetBool("IsWalking", isWalking);
            _animator.SetBool("IsPanicking", isPanicking);
        }
        public void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag.Equals("Fox"))
            {
                AttractGuardsInDistance a = GetComponentInChildren<AttractGuardsInDistance>();
                if (a)
                {
                    a.callGuards();
                }
            }
        }
    }

}