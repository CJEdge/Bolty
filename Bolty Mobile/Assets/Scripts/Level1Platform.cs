using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Platform : MonoBehaviour
{
    BoltCounter boltcounter;
    BoltyMovement player;

    void Start()
    {
        boltcounter = FindObjectOfType<BoltCounter>();
        player = FindObjectOfType<BoltyMovement>();
    }


    private void OnCollisionStay2D(Collision2D col)
    {
        if (boltcounter.totalProjectiles == 0)
        {
            player.levelFinished = true;
            boltcounter.LevelComplete();
        }
    }
}
