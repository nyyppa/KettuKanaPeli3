using UnityEngine;
using System.Collections;

namespace Kettukanapeli {
	public class PickKey : MonoBehaviour {
		public GameObject keyInMouth;

		void OnTriggerStay(Collider collider){
			if(collider.gameObject.tag.Equals ("Key") && !keyInMouth.activeSelf) {				// & action button pressed
				keyInMouth.SetActive(true);
			}
		}
		
		void OnTriggerEnter(Collider collider) {
			if (collider.gameObject.tag.Equals ("Locked") && keyInMouth.activeSelf) {
				keyInMouth.SetActive(false);
			}
		}

	}
}
