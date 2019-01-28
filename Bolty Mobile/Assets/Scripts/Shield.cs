using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    Animator anim;
    BoltyMovement playerInput;
    public bool shielding;
    public float shieldMeter = 20;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponentInParent<BoltyMovement>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && playerInput.dashing == false && shieldMeter > 0)
        {
            if (playerInput.grounded == true)
            {
                StandingShield();
                shieldMeter -= Time.deltaTime;
            }
            else HoveringShield();
            shieldMeter -= Time.deltaTime;
        }
        else if (!Input.GetKey(KeyCode.Z))
        {
            NoShield();
        }
    }

    void NoShield()
    {
        shielding = false;
        anim.SetBool("NoShield", true);
        anim.SetBool("StandingShield", false);
        anim.SetBool("HoveringShield", false);
    }

    void StandingShield()
    {
        shielding = true;
        anim.SetBool("NoShield", false);
        anim.SetBool("StandingShield", true);
        anim.SetBool("HoveringShield", false);
    }


    void HoveringShield()
    {
        shielding = true;
        anim.SetBool("NoShield", false);
        anim.SetBool("StandingShield", false);
        anim.SetBool("HoveringShield", true);
    }
}
