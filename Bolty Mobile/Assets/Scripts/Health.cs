using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static float PlayerHealth;
    public GameObject gameOver;
    private BoltyMovement boltyMovement;

    private void Start()
    {
        boltyMovement = FindObjectOfType<BoltyMovement>();
        PlayerHealth = 50;
        gameOver.SetActive(false);
    }

    private void Update()
    {
        if (PlayerHealth <= 0)
        {
            boltyMovement.Die();
            gameOver.SetActive(true);
        }
    }

    public void DealDamage(float damage)
    {
        PlayerHealth -= damage;
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
