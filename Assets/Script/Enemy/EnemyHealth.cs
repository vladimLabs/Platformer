using UnityEngine;

public class EnemyHealth : CreatureHealth
{
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private Animator animator;
    [SerializeField] private EnemyAttackGeneral attacker;
    [SerializeField] private CreatureMove move;
    [SerializeField] private CapsuleCollider2D capsule;
    [SerializeField] private Rigidbody2D rb;
    private bool isDead = false;
    public void GetDamage(float damage)
    {
        health -= damage;
        particle.Play();
        if (health < 0 && !isDead)
        {
            isDead = true;
            Death();
        }
    }

    private void Death()
    {
        animator.SetTrigger("Death");
        rb.gravityScale = 0;
        rb.linearVelocity = new Vector2(0, 0);
        attacker.startAttack = false;
        capsule.enabled = false;
        //attacker.enabled = false;
        move.canMove = false;
        this.enabled = false;
    }
}
