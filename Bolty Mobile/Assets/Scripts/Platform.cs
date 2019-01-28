using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool furthestLeft;
    public bool furthestRight;
    public bool closestToEndPlatform;
    private BoltCounter boltCounter;

    private void Start()
    {
        boltCounter = FindObjectOfType<BoltCounter>();
    }

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
            else if (furthestLeft)
            {
                player.onFurthestLeft = true;
            }
            else if (!furthestLeft)
            {
                player.onFurthestLeft = false;
            }
        }
    }

    private void Update()
    {
        if (closestToEndPlatform && boltCounter.totalProjectiles == 0)
        {
            furthestLeft = false;
            furthestRight = false;
        }
    }

}
