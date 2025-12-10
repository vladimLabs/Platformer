using System.Collections;
using UnityEngine;

public class PleayrMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector3 Indentation;
    [SerializeField] private float checkRadius = 0.2f;
    [SerializeField] private GameObject objectToRotate;
    [SerializeField] private Transform rightWallCollision;
    [SerializeField] private float timeJump;
    [SerializeField] private Animator animator;

    private bool wallJumping;

    void Update()
    {
        if (!wallJumping)
        {
            Move();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                Jump();
            }
            else if (CheckWall(rightWallCollision))
            {
                Jump();
                WallJump(-1);
            }
        }

        FlipCharacter();
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position + Indentation, checkRadius);
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        animator.SetBool("Walk", horizontalInput != 0);
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.linearVelocityY);
        rb.linearVelocity = movement;
    }

    private void WallJump(int direction)
    {
        StartCoroutine(JumpWall());
        //rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.AddForce(objectToRotate.transform.right * jumpForce * direction, ForceMode2D.Impulse);
        print("Jump");

    }

    private bool CheckWall(Transform wallCheck)
    {
        return Physics2D.OverlapCircle(wallCheck.position, checkRadius, groundLayer);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(transform.position + Indentation, checkRadius, groundLayer);
    }

    private IEnumerator JumpWall()
    {
        wallJumping = true;
        yield return new WaitForSeconds(timeJump);
        wallJumping = false;
    }

    public void Dash()
    {
        StartCoroutine(JumpWall());
        //rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.AddForce(objectToRotate.transform.right * jumpForce, ForceMode2D.Impulse);
    }

    private void FlipCharacter()
    {
        if (rb.linearVelocityX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (rb.linearVelocityX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}