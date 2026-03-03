using Unity.VisualScripting;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            return;
        }
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (!playerHealth.isDeflecting)
            {
                playerHealth.GetDamage(damage);
            }
        }
    }
}
