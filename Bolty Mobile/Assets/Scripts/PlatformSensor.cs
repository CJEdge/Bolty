using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSensor : MonoBehaviour
{
    public bool furthestLeft;
    public bool furthestRight;

    void OnTriggerStay2D(Collider2D collider)
    {
        BoltyMovement player = collider.gameObject.GetComponent<BoltyMovement>();
        if (player)
        {
            if (furthestRight)
            {
                player.onFurthestRight = true;
            }
            else if (!furthestRight)
            {
                player.onFurthestRight = false;
            }


            if (furthestLeft)
            {
                player.onFurthestLeft = true;
            }
            else if (!furthestLeft)
            {
                player.onFurthestLeft = false;
            }
        }
    }
}
