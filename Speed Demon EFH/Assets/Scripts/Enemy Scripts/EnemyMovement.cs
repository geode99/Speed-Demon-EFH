using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 8f;
    public float moveSpeed = 4f;
    public float jumpForce = 8f;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform ledgeCheck;
    public float wallRayLength = 0.5f; // How far to check for walls

    private Rigidbody2D rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Ground check
        if (groundCheck != null)
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        // Only track and move if within detection range
        if (distanceToPlayer <= detectionRange)
        {
            // Determine direction
            float direction = Mathf.Sign(player.position.x - transform.position.x);

            // Move towards player
            rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);

            // Ledge and wall check: if not grounded ahead or wall detected, jump
            if (isGrounded && ledgeCheck != null)
            {
                // Ledge check (below ledgeCheck)
                bool ledgeAhead = Physics2D.OverlapCircle(ledgeCheck.position + Vector3.down * 0.1f, groundRadius, groundLayer);

                // Wall check using raycast
                RaycastHit2D wallHit = Physics2D.Raycast(
                    ledgeCheck.position,
                    new Vector2(direction, 0),
                    wallRayLength,
                    groundLayer
                );
                bool wallAhead = wallHit.collider != null;

                if (!ledgeAhead || wallAhead)
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                }
            }
        }
        else
        {
            // Stop moving if player is out of range
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }
}
