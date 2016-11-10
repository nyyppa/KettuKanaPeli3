using UnityEngine;
using System.Collections;

namespace Kettukanapeli
{
    public class TriggerDetect : MonoBehaviour
    {

        public Transform m_tSpawnObject;
        private Transform m_gcTransform;

        public void Start()
        {
            m_gcTransform = GetComponent<Transform>();
        }

        public void OnTriggerEnter(Collider col)
        {
            GameObject.Instantiate(m_tSpawnObject, m_gcTransform.position, Quaternion.identity);
        }
    }
}
