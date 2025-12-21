using Unity.VisualScripting;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameAnalyticsManager.ErrorEvent();
            collision.GetComponent<PleayrHealth>().GetDamage(damage);
        }
    }
}
