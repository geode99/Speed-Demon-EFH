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
    public float coyoteTime = 0.2f; // Duration of coyote time in seconds

    private Rigidbody2D rb;
    private float accelerationTimerX = 0f;
    private bool isGrounded = false;
    private float airResist = 1f;
    private float coyoteTimeCounter = 0f;
    public float scaleFactor = 0.7f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");

        // Exponential acceleration for X
        if (moveX != 0){
            accelerationTimerX += Time.deltaTime;
        }else{
            accelerationTimerX = 0f;
        }
        // Flip player sprite based on movement direction
        if (moveX > 0){
            transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
        }else if (moveX < 0){
            transform.localScale = new Vector3(-scaleFactor, scaleFactor, scaleFactor);
        }
        float velocityX = maxSpeed * moveX * (1 - Mathf.Exp(-accelerationRate * accelerationTimerX));
        float velocityY = rb.linearVelocity.y;

        // Ground check
        if (groundCheck != null) {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
        }

        // Coyote time logic
        if (isGrounded) {
            coyoteTimeCounter = coyoteTime;
            airResist = 1f;
        }
        else {
            coyoteTimeCounter -= Time.deltaTime;
            airResist = 0.8f;
        }

        rb.linearVelocity = new Vector2(velocityX * airResist, velocityY);

        // Jump input (spacebar) 
        if (Keyboard.current.spaceKey.wasPressedThisFrame && coyoteTimeCounter > 0f){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            coyoteTimeCounter = 0f;
        }
    }
}