using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speedEnemy;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform player;
    [SerializeField] private float distance;
    [SerializeField] private Animator animator;

    void Update()
    {
        if (IsRaged())
        {
            MoveEnemy();
        }
    }

    private bool IsRaged()
    {
        return Vector3.Distance(rb.position, player.position) <= distance;
    }

    private void MoveEnemy()
    {
        if(player.transform.position.x > transform.position.x) gameObject.transform.localScale = new Vector3(-1, 1, 1);
        else gameObject.transform.localScale = new Vector3(1, 1, 1);
        Vector2 movement = new Vector2(speedEnemy * transform.localScale.x * -1, rb.linearVelocityY);
        animator.SetBool("IsWalking", rb.linearVelocity.magnitude > 0);
        rb.linearVelocity = movement;
    }
}
