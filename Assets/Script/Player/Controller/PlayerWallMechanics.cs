using UnityEngine;

public class PlayerWallMechanics : MonoBehaviour
{
    [Header("Wall Settings")]
    [SerializeField] private Transform rightWallCheck;
    [SerializeField] private float wallCheckRadius = 0.2f;
    [SerializeField] private float wallJumpDuration = 0.3f;
    [SerializeField] private LayerMask groundLayer;
    
    [Header("Wall Run Settings")]
    [SerializeField] private string wallRunTag = "Wallrun";

    private bool isWallJumping;
    private bool isWallRunning;
    private bool canWallRun;
    private float wallJumpTimer;

    public bool IsWallJumping => isWallJumping;

    private void Update()
    {
        if (isWallJumping)
        {
            wallJumpTimer -= Time.deltaTime;
            if (wallJumpTimer <= 0)
            {
                isWallJumping = false;
                gameObject.layer = 3; 
            }
        }
    }

    public bool CheckWall(Transform wallCheck)
    {
        return Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, groundLayer);
    }

    public bool CanWallJump()
    {
        return CheckWall(rightWallCheck) && !isWallJumping;
    }

    public int GetWallDirection()
    {
        if(transform.rotation.x == 0) 
            return -1;
        if(transform.rotation.x != 0) 
            return 1;
        return 0;
    }

    public void StartWallJump()
    {
        isWallJumping = true;
        wallJumpTimer = wallJumpDuration;
        gameObject.layer = 8; 
    }

    public void HandleWallRunStay(Collider2D other, bool isJumpHeld)
    {
        if (!other.CompareTag(wallRunTag)) return;

        canWallRun = true;
        
        if (isJumpHeld && !isWallJumping)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            isWallRunning = true;
        }
    }

    public void HandleWallRunExit(Collider2D other)
    {
        if (other.CompareTag(wallRunTag))
        {
            isWallRunning = false;
            canWallRun = false;
        }
    }
}