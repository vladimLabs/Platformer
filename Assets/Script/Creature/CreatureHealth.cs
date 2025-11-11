using UnityEngine;

public abstract class CreatureHealth : MonoBehaviour
{
    [SerializeField] protected int health;
    protected int healMax => health;

    public virtual void GetDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }

    public virtual void GetHeal(int heal)
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
