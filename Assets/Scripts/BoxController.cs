using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//minimum x = -8.375
//maximum x = 8.375

public class BoxController : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 moveDirection = Vector2.zero;
    private float leftBoundary = -8.375f;
    private float rightBoundary = 8.375f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void LaunchBox(Vector2 direction)
    {
        // Disable gravity
        rb.gravityScale = 0;
        moveDirection = direction;
    }

    void StopBox()
    {
        moveDirection = Vector2.zero;
        // Re-enable gravity
        rb.gravityScale = 1;
    }

    void Update()
    {
        if (moveDirection != Vector2.zero)
        {
            // Move the box in the direction determined by the collision
            LaunchBox(moveDirection);
            transform.Translate(moveDirection * speed * Time.deltaTime);
        }

        // Check for boundary conditions to stop the box
        if (transform.position.x <= leftBoundary || transform.position.x >= rightBoundary)
        {
            StopBox();
            moveDirection = Vector2.zero; // Stops the box
            rb.velocity = Vector2.zero;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check for collision with Player1 and if Player1 is grounded
        if (collision.gameObject.tag == "Player1" && collision.gameObject.GetComponent<RedPlayerController>().IsGrounded())
        {
            Vector2 contactPoint = collision.GetContact(0).point;
            Vector2 center = transform.position;
            bool isRightSide = contactPoint.x > center.x;
            LaunchBox(isRightSide ? Vector2.left : Vector2.right);
        }
    }
    
}
