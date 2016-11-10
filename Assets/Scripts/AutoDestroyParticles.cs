using UnityEngine;
using System.Collections;

namespace Kettukanapeli
{
    public class AutoDestroyParticles : MonoBehaviour
    {

        private ParticleSystem m_gcParticles;

        public void Start()
        {
            m_gcParticles = GetComponent<ParticleSystem>();
        }

        void Update()
        {
            if (!m_gcParticles.IsAlive(true))
            {
                Destroy(gameObject);
            }
        }
    }
}
