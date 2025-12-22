using System;
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

    private bool canDash = true;
    private bool wallJumping;
    private bool isWallrunning;

    void Update()
    {
        if (!wallJumping)
        {
            Move();
            animator.SetBool("IsGrounded", IsGrounded());
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

        if (canDash && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
            animator.SetTrigger("Dash");
        }

        if (isWallrunning && Input.GetKeyUp(KeyCode.Space))
        {
            Jump();
        }

        FlipCharacter();
    }

    private void Jump()
    {
        animator.SetTrigger("Jump");
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
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
        animator.SetBool("IsWalking", horizontalInput != 0);
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
        gameObject.layer = 8;
        yield return new WaitForSeconds(timeJump);
        gameObject.layer = 3;
        wallJumping = false;
        yield return new WaitForSeconds(timeJump * 2);
        canDash = true;
    }

    public void Dash()
    {
        canDash = false;
       
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

    private void OnTriggerStay2D(Collider2D other)
    {
     
        if (other.CompareTag("Wallrun") && Input.GetKey(KeyCode.Space) && !wallJumping)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            isWallrunning = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Wallrun"))
        {
            isWallrunning = false;
        }
    }
}