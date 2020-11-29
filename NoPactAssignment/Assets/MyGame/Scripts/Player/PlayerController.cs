using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    [SerializeField] protected float jumpForce = 600f;
    [SerializeField] protected LayerMask determineGround;
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float specialJumpForce = 200f;
    [SerializeField] protected float specialJumpStall = 2f;
    [SerializeField] [Range(0, .3f)] protected float movementSmoothness = 0.05f;

    [SerializeField] protected const float groundedCheckRadius = 0.2f;
    protected bool isGrounded;
    protected Rigidbody2D rb;
    protected bool isFacingRight = true;
    protected Vector3 velocity = Vector3.zero;
    protected bool canMove = true;
    protected bool canSpecial = true;

    public void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public abstract void FixedUpdate();
    public abstract void Move(float move, bool jump); 
}
