using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    private Health playerHealth;
    void Start()
    {
        healthBar = GetComponent<Slider>();
        playerHealth = GameObject.FindObjectOfType<Health>();
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = playerHealth.health; 
    }
}
