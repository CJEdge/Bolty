using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public Slider shieldBar;
    private Shield shield;
    void Start()
    {
        shieldBar = GetComponent<Slider>();
        shield = GameObject.FindObjectOfType<Shield>();

    }

    // Update is called once per frame
    void Update()
    {
        shieldBar.value = shield.shieldMeter;
    }
}
