using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public GameObject gameOver;
    Animator anim;

    private void Start()
    {
        health = 50;
        anim = GetComponent<Animator>();
        gameOver.SetActive(false);
    }

    private void Update()
    {
        if (health <= 0)
        {
            gameOver.SetActive(true);
            anim.SetBool("Die", true);
        }
    }

    public void DealDamage(float damage)
    {
        health -= damage;
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
