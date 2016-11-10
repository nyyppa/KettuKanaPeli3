using UnityEngine;
using System.Collections;

namespace Kettukanapeli
{
    public class ChickenPanic : MonoBehaviour
    {
        public float PanicTime = 5;
        float timeSpendInPanic = 10;
        Animator _animator;

        void Start()
        {
            _animator = GetComponentInParent<Animator>();
        }

        void Update()
        {
            timeSpendInPanic += Time.deltaTime;
            if (timeSpendInPanic < PanicTime)
            {
                if (_animator)
                {
                    _animator.SetBool("IsPanicking", true);
                }
            }
            else
            {
                if (_animator)
                {
                    _animator.SetBool("IsPanicking", false);
                }
            }
        }
        void OnTriggerEnter(Collider collider)
        {
            if (collider.tag.Equals("Fox"))
            {
                AttractGuardsInDistance a = GetComponentInChildren<AttractGuardsInDistance>();
                panic();
                if (a)
                {
                    a.callGuards();
                }
            }
        }
        void OnTriggerStay(Collider collider)
        {
            if (collider.tag.Equals("Fox"))
            {
                AttractGuardsInDistance a = GetComponentInChildren<AttractGuardsInDistance>();
                panic();
                if (a)
                {
                    a.callGuards();
                }
            }
        }

        void panic()
        {
            timeSpendInPanic = 0;
        }
    }
}