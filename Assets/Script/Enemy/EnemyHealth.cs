using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health;

    public void GetDamage(float damage)
    {
        health -= damage;

        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
}
