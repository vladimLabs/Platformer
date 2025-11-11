using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Vector2 dir;
    [SerializeField] private float damage;

    private void Update()
    {
        transform.Translate(dir * Time.deltaTime );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().GetDamage(damage);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
