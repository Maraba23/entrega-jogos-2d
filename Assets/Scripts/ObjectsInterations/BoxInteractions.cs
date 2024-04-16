using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInteractions : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            RedPlayerController playerRed = collision.gameObject.GetComponent<RedPlayerController>();
            BluePlayerController playerBlue = collision.gameObject.GetComponent<BluePlayerController>();

            if (playerRed != null)
            {
                playerRed.animator.SetTrigger("pushTrigger");
                rb.velocity = new Vector2(playerRed.transform.localScale.x * playerRed.maxSpeed, rb.velocity.y);
            }
            else if (playerBlue != null)
            {
                rb.AddForce(new Vector2(1, 0) * 10);
            }
        }
    }
}
