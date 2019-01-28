using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltyMovement : MonoBehaviour
{
    //MOVEMENT STATS
    public float jumpHeight;
    public float hoverJumpHeight;
    public float dashSpeed;

    //EXPOSES
    private Rigidbody2D rb;
    private Animator anim;
    private Shield shield;
    public Joystick joystick;
    private bool facingLeft;

    //MOVEMENT ESSENTIALS
    private Vector3 StartPos; // starting position for character
    public bool movingInX; // player must not be moving to use any movement controls
    public bool boosting; // is the player using boost ( boost is needed for all movement except ducking)
    public bool levelFinished; // is the player on the final platform

    //VERTICAL MOVEMENT VARIABLES
    public bool grounded; // is the player touching a platform
    public bool jumping; // is the player using the jump move
    public bool hoverMove;// is the player using the hover move
    public bool duck; // is the player using the duck move
    public bool falling; // is the player falling

    //HORIZONTAL MOVEMENT VARIABLES

    public bool onFurthestRight; //is the player on the furthest right platform
    public bool onFurthestLeft; //is the player on the furthest left platform

    public bool hovering; // is the player holding boost in the air
    public bool dashing; // is the player moving horizontally
    public bool airDashing; // is the player boosting and dashing at the same time
    public bool dashReset; // can i dash again yet
    
    void Start()
    {
        //EXPOSES
        shield = GetComponentInChildren<Shield>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        rb.velocity = new Vector2(0, 0); 
        StartPos = transform.position; // 0 velocity and set start position
        dashReset = true; // your dash is reset upon spawning
        levelFinished = false;
    }
    
    void Update()
    {
        if (shield.shielding == false && !levelFinished) // you cant move and shield or if the level is over
        {
            //DUCK--------------------------------------------------
            if (joystick.Vertical <= -0.6f && grounded && !movingInX && !boosting) // you can duck when you are on the ground, not moving and not boosting
            {
                anim.SetBool("Duck", true);
                duck = true;
            }
            else
                anim.SetBool("Duck", false); 
                duck = false;

            
            //HOVER MOVE----------------------------------------------
            if (joystick.Horizontal == 0 && joystick.Vertical == 0 && grounded && !movingInX && !airDashing && boosting && !falling) // you can hover when you only boost and you are on the ground an not moving
            {
                anim.SetBool("HoverMove", true);
                hoverMove = true;
            }

            //JUMP-----------------------------------------------------------
            if (joystick.Vertical >= 0.6f && grounded && !movingInX && boosting && !falling) // you can jump when ou are on the ground, not moving
            {
                anim.SetBool("Jump", true);
                jumping = true;
            }
            if (joystick.Vertical >= 0.6f && !movingInX && hoverMove && !jumping) // you can jump from the hover move if you are not moving or already jumping
            {
                anim.SetBool("Jump", true);
                jumping = true;
            }
            //CHECK IF MOVING HORIZONTALLY-------------------------------------------
            if (rb.velocity.x > 1 || -1 > rb.velocity.x)
            {
                movingInX = true;
            }
            else if (rb.velocity.x < 1 || -1 < rb.velocity.x)
            {
                movingInX = false;
            }

            //RIGHT DASH------------------------------------------------------------------
            if (joystick.Horizontal >= 0.6f && !dashing && grounded && !movingInX && !jumping && dashReset) // you can dash when you are on the ground,not moving and not already dashing
            {
                if (facingLeft)
                {
                    Flip();
                }
                if (!duck && !onFurthestRight && boosting)
                {
                    dashing = true;
                    anim.SetBool("Dash", true);
                    dashReset = false;
                }

            }
            //LEFT DASH-----------------------------------------------------------------------
            if (joystick.Horizontal <= -0.6f && !dashing && grounded && !movingInX && !jumping && dashReset)
            {
                if (!facingLeft)
                {
                    Flip();
                }
                if (!duck && !onFurthestLeft && boosting)
                {
                    dashing = true;
                    anim.SetBool("Dash", true);
                    dashReset = false;
                }
            }

            //DASH RESET
            if (joystick.Horizontal == 0) // you must let go of the arrow keys again to dash
            {
                dashReset = true;
            }

            //AIRBORN DASH-----------------------------------------------------------------------
            if (hovering && !airDashing &&!movingInX)
            {
                if (joystick.Horizontal >= 0.6f)
                {
                    if (facingLeft)
                    {
                        Flip();
                    }
                    if (!onFurthestRight)
                    {
                        anim.SetBool("AirDash", true);
                        airDashing = true;
                    }
                }
                if (joystick.Horizontal <= -0.6f)
                {
                    if (!facingLeft)
                    {
                        Flip();
                    }
                    if (!onFurthestLeft)
                    {
                        anim.SetBool("AirDash", true);
                        airDashing = true;
                    }
                }
            }
        }
    }

    // BOOST----------------------------------------------
    public void Boosting()
    {
        boosting = true;
    }
    public void NotBoosting()
    {
        boosting = false;
        if (!movingInX && !grounded)
        {
            falling = true;
            anim.SetBool("Fall", true); //if you arent boosting and you arent moving you will fall
        }
    }
    //GRAVITY FREEZING----------------------------------------
    void FreezeGravity()
    {
        rb.gravityScale = 0;
        rb.velocity = new Vector2(rb.velocity.x, 0);
    }
    void UnFreezeGravity()
    {
        grounded = false;
        anim.SetBool("Grounded", false);
        rb.gravityScale = 1;
        
    }

    //JUMP------------------------------------------------------------
    void Jump ()
    {
            if (hoverMove && !jumping)
            {
                FreezeGravity();
            }
            else if (hoverMove)
        {
            rb.velocity = new Vector2(0, hoverJumpHeight);
            anim.SetBool("Jump", true);
            anim.SetBool("HoverMove", false);
        }
            else
            rb.velocity = new Vector2(0, jumpHeight);
    }

    //DASH----------------------------------------------------------------
    void Dash()
    {
        if(facingLeft)
        {
            rb.velocity = new Vector2(-dashSpeed, 0);
        }
        else if (!facingLeft)
        {
            rb.velocity = new Vector2(dashSpeed, 0);
        }
    }

    // WHILST TOUCHING THE GROUND---------------------------------------------
    private void OnCollisionStay2D(Collision2D ground)
    {
        if (ground.gameObject.tag == "Ground")
        {
            anim.SetBool("Fall", false);
            anim.SetBool("Grounded", true);
            anim.SetBool("AirDash", false);
            anim.SetBool("HoverMove", false);
            grounded = true;
            falling = false;
            hoverMove = false;
           
        }
    }

    // ON FIST CONTACT WITH THE GROUND-----------------------------------------------------
    private void OnCollisionEnter2D(Collision2D ground)
    {
        if (ground.gameObject.tag == "Ground")
        {
            dashing = false;
            anim.SetBool("Dash", false);
        }
    }

    //WHEN LEAVING THE GROUND---------------------------------------------------------
    private void OnCollisionExit2D(Collision2D ground)
    {
        if (ground.gameObject.tag == "Ground")
        {
            anim.SetBool("Grounded", false);
            grounded = false;
        }
    }

    // WHEN FIRST ABOVE A PLATFORM--------------------------------------------------------------
    private void OnTriggerEnter2D(Collider2D ground)
    {
        if (ground.gameObject.tag == "Ground")
        {
            airDashing = false;
            anim.SetBool("AirDash", false);
        }
    }

    // WHILE ABOVE A PLATFORM-----------------------------------------------------------------------------
    private void OnTriggerStay2D(Collider2D ground)
    {

        if (ground.gameObject.tag == "Ground")
        {
            if (!dashing && !airDashing)
            {

                if (transform.position.x <= (ground.transform.position.x + 0.1) || transform.position.x > (ground.transform.position.x - 0.1))
                {
                    Vector3 freezePos = new Vector3(ground.transform.position.x, transform.position.y, -1);
                    rb.velocity = new Vector2(0, rb.velocity.y);
                    transform.position = freezePos;
                }
            }
        }
    }
    
    public void Jumping()
    {
        jumping = true;
    }
    
    public void Falling()
    {
        jumping = false;
        hoverMove = false;
        hovering = false;
        falling = true;
        anim.SetBool("HoverMove", false);
        anim.SetBool("Jump", false);
        anim.SetBool("Fall", true);
    }
    
    public void Hover()
    {
        hovering = true;
        falling = false;
        anim.SetBool("Fall", false);
    }
    void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void ResetTransform()
    {
        transform.position = StartPos;
    }
}
