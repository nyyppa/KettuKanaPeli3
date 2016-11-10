using UnityEngine;
using System.Collections;

namespace Kettukanapeli
{
    public class SpawnPoint : MonoBehaviour
    {
        static SpawnPoint spawnPoint;
        public GameObject guard;
        static GameObject Guard;
        // Use this for initialization
        void Start()
        {
            spawnPoint = this;
            Guard = guard;
        }

        // Update is called once per frame
        void Update()
        {

        }
        public static void SpawnGuard()
        {
            GameObject gameObject = (GameObject)Instantiate(Guard, spawnPoint.transform.position, spawnPoint.transform.rotation);
            gameObject.SetActive(true);
        }
        public void SpawnGuard2()
        {
            GameObject gameObject = (GameObject)Instantiate(Guard, spawnPoint.transform.position, spawnPoint.transform.rotation);
            gameObject.SetActive(true);
        }

    }
}