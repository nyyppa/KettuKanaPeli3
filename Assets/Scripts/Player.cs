using UnityEngine;
using System.Collections;

namespace Kettukanapeli
{
	public class Player : MonoBehaviour
	{
		private void OnDisable()
		{
			GameManager.Instance.GameOver ();
		}
	}
}
