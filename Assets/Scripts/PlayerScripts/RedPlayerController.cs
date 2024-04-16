using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayerController : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private bool isGrounded = true;
    public string playerColor = "Red";
    public Animator animator;
    private bool facingRight = true;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveX = 0f;
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            moveX = 0f;
            animator.SetBool("isWalking", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
            animator.SetBool("isWalking", true);
            if (facingRight)
            {
                FlipSprite();
            }
            facingRight = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
            animator.SetBool("isWalking", true);
            if (!facingRight)
            {
                FlipSprite();
            }
            facingRight = true;
        }

        else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalking", false);
        }

        rb.velocity = new Vector2(moveX * maxSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
            animator.SetBool("isGrounded", false);
        }
        else if (Input.GetKeyDown(KeyCode.S) && !isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Box")
        {
            isGrounded = true;
            animator.SetBool("isGrounded", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Box" && !isGrounded) || collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
            animator.SetBool("isGrounded", false);
        }
    }

    public void FlipSprite() 
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }
}
