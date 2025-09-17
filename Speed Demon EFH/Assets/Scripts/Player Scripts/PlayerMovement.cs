using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 20f;
    public float accelerationRate = 15f;
    public float jumpForce = 1f;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;
    

    private Rigidbody2D rb;
    private float accelerationTimerX = 0f;
    private bool isGrounded = false;
    private float airResist = 1f;

    //coyote time variables
    private float coyoteCounter = 4f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Exponential acceleration for X
        if (moveX != 0) {
            accelerationTimerX += Time.deltaTime;
        } else {
            accelerationTimerX = 0f;
        }
        if (!isGrounded) {
            coyoteCounter -= 1f;
        }else {
            coyoteCounter = 40f;
        }
        // Exponential acceleration for 

        float velocityX = maxSpeed * moveX * (1 - Mathf.Exp(-accelerationRate * accelerationTimerX));
        float velocityY = rb.linearVelocity.y;
        if (isGrounded) {
            airResist = 1f;
        }
        else {
            airResist = 0.8f;
        }
        rb.linearVelocity = new Vector2(velocityX*airResist, velocityY);
        // Ground check
        if (groundCheck != null) {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
        }
        // Jump input (spacebar)
        if (Keyboard.current.spaceKey.wasPressedThisFrame && coyoteCounter >= 0){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}