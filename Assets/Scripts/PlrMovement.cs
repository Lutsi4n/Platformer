using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlrMovement : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private float speed;

    [Header("Settings")]
    [SerializeField] private Transform groundColTrans;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float jumpOffset;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Animator animator;
    private string crrntAnimtaion;
    private bool facingRight = true;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    private void FixedUpdate()
    {
        Vector3 overlapCirclePosition = groundColTrans.position;
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);
    }

    public void Move(float direction, bool isJumpBtnPrssd)
    {
        if (isJumpBtnPrssd)
        {
            Jump();
        }
        if (isGrounded)
        {
            if (direction != 0)
            {
                ChangeAnim("Kn_Run");
                HorizontalMove(direction);
            }
            else
            {
                ChangeAnim("idle");
            }
        }
        else
        {
            ChangeAnim("Kn_jump3");
        }

        if (direction < 0 && facingRight)
        {
            Flip();
        }
        if (direction > 0 && !facingRight)
        {
            Flip();
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void HorizontalMove(float direction)
    {
         rb.velocity = new Vector2( direction * speed, rb.velocity.y);
    }

    private void ChangeAnim(string animName)
    {
        if (crrntAnimtaion == animName) return;

        animator.Play(animName);
        crrntAnimtaion= animName;
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
