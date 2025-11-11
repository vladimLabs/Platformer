using UnityEngine;

public class WeaponHitBox : MonoBehaviour
{
    public float Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag ("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().GetDamage(Damage);
        }
    }
}
