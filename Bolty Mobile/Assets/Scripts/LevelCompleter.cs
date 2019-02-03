using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleter : MonoBehaviour
{
    BoltCounter boltcounter;
    Animator anim;
    BoltyMovement player;
    public GameObject directionalArrow;

    void Start()
    {
        anim = GetComponent<Animator>();
        boltcounter = FindObjectOfType<BoltCounter>();
        player = FindObjectOfType<BoltyMovement>();
        anim.SetTrigger("LevelComplete");
        directionalArrow.SetActive(true);
    }
    

    private void OnCollisionEnter2D(Collision2D col)
    {
        player.levelFinished = true;
        boltcounter.LevelComplete();
    }

    private void OnBecameVisible()
    {
        directionalArrow.SetActive(false);
    }

    private void OnBecameInvisible()
    {
        directionalArrow.SetActive(true);
    }
}
