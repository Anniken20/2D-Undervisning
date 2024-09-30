using System.Collections;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    // Movement parameters
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public bool isGrounded = false;  // To check if the player is on the ground
    public Transform groundCheck;    // Ground check reference
    public LayerMask groundLayer;     // Layer to specify ground objects

    // Power-up flags
    private bool isSpeedBoostActive = false;
    private bool isInvincible = false;

    // Power-up parameters
    public float speedBoostMultiplier = 2f;
    public float speedBoostDuration = 5f;
    public float invincibilityDuration = 5f;

    // Components
    private Rigidbody2D rb;
    //private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MovePlayer();
        Jump();
        GroundCheck();
    }

    // Handle player movement (left/right)
    void MovePlayer()
    {
        float moveInput = Input.GetAxis("Horizontal");

        // Apply movement
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip player sprite based on direction
        if (moveInput > 0)
        {
            //spriteRenderer.flipX = false;
        }
        else if (moveInput < 0)
        {
            //spriteRenderer.flipX = true;
        }
    }

    // Handle player jump
    void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void GroundCheck()
    {
        // Cast a circle downward to detect if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }


    // Power-up pickups
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpeedBoost"))
        {
            StartCoroutine(SpeedBoost());
            Destroy(collision.gameObject);  // Remove power-up after use
        }
        else if (collision.CompareTag("Invincibility"))
        {
            StartCoroutine(Invincibility());
            Destroy(collision.gameObject);  // Remove power-up after use
        }
    }

    // Speed boost power-up
    private IEnumerator SpeedBoost()
    {
        isSpeedBoostActive = true;
        moveSpeed *= speedBoostMultiplier;

        // Wait for the duration of the speed boost
        yield return new WaitForSeconds(speedBoostDuration);

        // Reset speed after boost ends
        moveSpeed /= speedBoostMultiplier;
        isSpeedBoostActive = false;
    }

    // Invincibility power-up
    private IEnumerator Invincibility()
    {
        isInvincible = true;
        //spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);  // Make the player semi-transparent as feedback for invincibility

        // Wait for the duration of invincibility
        yield return new WaitForSeconds(invincibilityDuration);

        // Reset player state
        //spriteRenderer.color = new Color(1f, 1f, 1f, 1f);  // Reset transparency
        isInvincible = false;
    }

    // Optional: Invincibility logic (e.g., ignoring damage)
    public bool IsInvincible()
    {
        return isInvincible;
    }
}

