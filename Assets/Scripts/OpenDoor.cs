﻿using UnityEngine;
using System.Collections;

namespace Kettukanapeli
{
    public class OpenDoor : UseStuff
    {
        public GameObject lockedDoor;

        public override void UseStuffAction()
        {
            if (lockedDoor)
            {
                lockedDoor.SetActive(false);
            }

            gameObject.SetActive(false);
        }
    }
}
