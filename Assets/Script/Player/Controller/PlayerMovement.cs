using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float wallJumpForce = 10f;
    
    [Header("Ground Check")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector3 groundCheckOffset;
    [SerializeField] private float groundCheckRadius = 0.2f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ProcessMovement(float horizontalInput)
    {
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }

    public void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void WallJump(int direction)
    {
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(new Vector2(direction * wallJumpForce, jumpForce), ForceMode2D.Impulse);
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(transform.position + groundCheckOffset, 
            groundCheckRadius, groundLayer);
    }

    public Vector2 GetVelocity() => rb.linearVelocity;
}