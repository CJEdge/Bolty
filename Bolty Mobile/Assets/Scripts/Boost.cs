using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public BoltyMovement player;
    void Start()
    {
        player = FindObjectOfType<BoltyMovement>();
    }

    public void BoostButtonDown()
    {
        player.boosting = true;
    }
    public void BoostButtonUp()
    {
        player.boosting = false;
        Debug.Log("stop boosting");
    }

}
