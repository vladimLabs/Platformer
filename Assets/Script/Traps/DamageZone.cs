using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private int damage;
    private PlayerHealth playerHealth;

    [Inject]
    private void Construct(PlayerHealth _playerHealth)
    {
        playerHealth = _playerHealth;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            return;
        }
        if (collision.CompareTag("Player"))
        {
            if (!playerHealth.isDeflecting)
            {
                playerHealth.GetDamage(damage);
            }
        }
    }
}
