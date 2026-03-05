using UnityEngine;

public abstract class CreatureHealth : MonoBehaviour
{
    [SerializeField] protected float health;
    protected float healMax => health;

    public virtual void GetDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }

    public virtual void GetHeal(float heal)
    {
        if (health + heal > healMax)
        {
            health = healMax;
        }
        health += heal;
    }

    protected virtual void Death()
    {
        
    }
}
