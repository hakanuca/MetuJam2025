using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private bool isJumping;
    private bool isFalling;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Move();
        Jump();
        UpdateAnimation();
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y); // Fix typo here from linearVelocity to velocity

        if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        else if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }

        animator.SetBool("isRunning", moveInput != 0);
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                isJumping = true;
                isFalling = false;
            }
        }
        else if (rb.linearVelocity.y < 0) // If the player is falling
        {
            isJumping = false;
            isFalling = true;
        }
    }

    void UpdateAnimation()
    {
        // Set the appropriate animation based on the player's state
        if (isGrounded)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }
        else
        {
            if (isJumping)
            {
                animator.SetBool("isJumping", true);
                animator.SetBool("isFalling", false);
            }
            else if (isFalling)
            {
                animator.SetBool("isJumping", false);
                animator.SetBool("isFalling", true);
            }
        }
    }
}
