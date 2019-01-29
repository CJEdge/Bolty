using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool closestToEndPlatform;
    private BoltCounter boltCounter;
    private PlatformSensor platformSensor;

    private void Start()
    {
        boltCounter = FindObjectOfType<BoltCounter>();
    }



    private void Update()
    {
        if (closestToEndPlatform && boltCounter.totalProjectiles == 0)
        {
            platformSensor.furthestLeft = false;
            platformSensor.furthestRight = false;
        }
    }

}
