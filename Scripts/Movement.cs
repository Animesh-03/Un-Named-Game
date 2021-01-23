using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    private float moveInput;
    public Rigidbody2D rb;

    private bool moveForward = true;

    private bool isOnGround;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask ground;
    public int jumpCount;
    public int jumpCountValue;
    public KeyCode jump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {

        isOnGround = Physics2D.OverlapCircle(groundCheck.position,checkRadius,ground);

        moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveInput*moveSpeed,rb.velocity.y);

        if (moveForward == true && moveInput<0)
        {
            flip();
        }
        else if (moveForward == false && moveInput > 0)
        {
            flip();
        }
       
    }

    void LateUpdate() {

        if(isOnGround == true) {
            {
                jumpCountValue = jumpCount;
            }
        }

         if(Input.GetKeyDown(jump) && jumpCountValue >= 1)
        {
            rb.velocity =Vector2.up*jumpForce;
            jumpCountValue--;
            Debug.Log(jumpCountValue);
        }

    }


    void flip()
    {
        moveForward = !moveForward;
        Vector3 Scale = transform.localScale;
        Scale.x*=-1;
        transform.localScale = Scale;   
    }
}
