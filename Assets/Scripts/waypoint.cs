using UnityEngine;
using System.Collections;

namespace Kettukanapeli
{
    public class waypoint : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            //print (other.tag);
            if (other.tag.Equals("Guard"))
            {
                GuardPatrol gp = other.GetComponent<GuardPatrol>();
                if (gp != null)
                {
                    gp.waypointReached(this);
                }
            }
        }

    }
}