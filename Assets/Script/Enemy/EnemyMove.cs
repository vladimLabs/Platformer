using UnityEngine;
using Zenject;

public class EnemyMove : CreatureMove
{
    [SerializeField] private float speedEnemy;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float distance;
    [SerializeField] private Animator animator;
    [SerializeField] private LayerMask obstacleLayerMask;
    private Transform player;

    [Inject]
    private void Construct(PlayerMovement _player)
    {
        player = _player.transform;
    }
    void Update()
    {
        if (IsRaged() && canMove)
        {
            MoveEnemy();
        }
    }

    private bool IsRaged()
    {
        if (Vector3.Distance(rb.position, player.position) <= distance)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, obstacleLayerMask);
            Debug.DrawRay(transform.position, direction, Color.red);
            print(hit.collider.name);
            if(!hit.transform.CompareTag("Player")) return false;
            print(hit.collider.name);
            return true;
        }
        return false;
    }
    

    private void MoveEnemy()
    {
        if(player.transform.position.x - transform.position.x > 1) gameObject.transform.localScale = new Vector3(-1, 1, 1);
        if(player.transform.position.x - transform.position.x < -1) gameObject.transform.localScale = new Vector3(1, 1, 1);
        Vector2 movement = new Vector2(speedEnemy * transform.localScale.x * -1, rb.linearVelocityY);
        animator.SetBool("IsWalking", rb.linearVelocity.magnitude > 0);
        rb.linearVelocity = movement;
    }

    public bool GetIsRaged()
    {
        return IsRaged();
    }
}
