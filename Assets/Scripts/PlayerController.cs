using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public Transform groundCheck;
    public LayerMask whatisGround;
    Rigidbody2D rb;
    bool isGrounded = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rb.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, .2f, whatisGround);
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }
}
