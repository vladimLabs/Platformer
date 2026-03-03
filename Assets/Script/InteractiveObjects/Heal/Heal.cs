using UnityEngine;

public class Heal : MonoBehaviour, IPickable
{
    [SerializeField] private int heal;

    public void PickUp()
    {
        FindAnyObjectByType<PlayerHealth>().GetHeal(heal);
        Destroy(gameObject);
    }
}
