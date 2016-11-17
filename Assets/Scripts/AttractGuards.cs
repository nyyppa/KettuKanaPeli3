using UnityEngine;
using System.Collections;

namespace Kettukanapeli
{
    public class AttractGuards : MonoBehaviour
    {
        public GuardPatrol[] guards;
        Rigidbody body;
       
        void Start()
        {
            body = GetComponent<Rigidbody>();
        }

        void Update()
        {
            /*if(body.velocity.x<-0.1f||body.velocity.z<-0.1f||body.velocity.x>0.1f||body.velocity.z>0.1f){
                for(int i=0;i<guards.Length;i++){
                    Vision v = guards [i].gameObject.GetComponentInChildren<Vision> ();
                    if(v){
                        Transform t = new GameObject ().transform;
                        t.position = transform.position + new Vector3 (1, 0, 1);
                        v.setVisionPoint (t);
                        Destroy (t.gameObject);
                    }
                }
            }*/
        }

        void OnCollisionEnter(Collision other)
        {
			CallGuards (other.collider.tag);
        }
		void OnTriggerEnter(Collider collider){
			CallGuards (collider.tag);
		}

		void CallGuards(string tag){
			if (tag.Equals("Fox"))
			{
				for (int i = 0; i < guards.Length; i++)
				{
					Vision v = guards[i].gameObject.GetComponentInChildren<Vision>();
					if (v)
					{
						Transform t = new GameObject().transform;
						t.position = transform.position + new Vector3(1, 0, 1);
						v.setVisionPoint(t);
						Destroy(t.gameObject);
					}
				}
			}
		}

    }


}
