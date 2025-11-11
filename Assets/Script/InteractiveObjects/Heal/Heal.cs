using UnityEngine;

public class Heal : MonoBehaviour, IPickable
{
    [SerializeField] private int heal;

    public void PickUp()
    {
        FindAnyObjectByType<PleayrHealth>().GetHeal(heal);
        Destroy(gameObject);
    }
}
