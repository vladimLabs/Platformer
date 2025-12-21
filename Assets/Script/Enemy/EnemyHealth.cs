using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float health;
    [SerializeField] private EnemyAttack attacker;
    [SerializeField] private EnemyMove move;
    [SerializeField] private CapsuleCollider2D capsule;
    [SerializeField] private Rigidbody2D rb;
    public void GetDamage(float damage)
    {
        health -= damage;

        if (health < 0)
        {
            animator.SetTrigger("Death");
            rb.gravityScale = 0;
            rb.linearVelocity = new Vector2(0, 0);
            capsule.enabled = false;
            attacker.enabled = false;
            move.enabled = false;
            this.enabled = false;
        }
    }
}
