using UnityEngine;
using Zenject;

public class Heal : MonoBehaviour, IPickable
{
    [SerializeField] private int heal;
    private PlayerHealth playerHealth;
    [Inject]
    private void Construct(PlayerHealth _playerHealth)
    {
        playerHealth = _playerHealth;
    }
    public void PickUp()
    {
        playerHealth.GetHeal(heal);
        Destroy(gameObject);
    }
}
