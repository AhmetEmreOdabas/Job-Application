using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceController : PlayerController
{
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override void FixedUpdate()
    {
        bool wasGrounded = isGrounded;
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedCheckRadius, determineGround);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
            }
        }
    }




    public override void Move(float move, bool jump)
    {
        if (canMove)
        {
            Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothness);
        }

        if (isGrounded && jump)
        {
            isGrounded = false;
            canSpecial = true;
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        else if (jump && canSpecial && !isGrounded)
        {
            canSpecial = false;
            rb.velocity = new Vector2(transform.localScale.x * specialJumpForce, specialJumpStall);
        }

        if (move > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (move < 0 && isFacingRight)
        {
            Flip();
        }

    }
}

