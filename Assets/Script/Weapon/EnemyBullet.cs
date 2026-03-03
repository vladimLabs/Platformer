using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private Vector2 dir;
    
    [SerializeField] private int damage;

    [SerializeField] private bool destroyByObstacles;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Time.deltaTime );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (!playerHealth.isDeflecting)
            {
                playerHealth.GetDamage(damage);
            }
            Destroy(gameObject);
        }

        if (destroyByObstacles)
        {
            if (collision.CompareTag("Obstacle"))
            {
                Destroy(gameObject);
            }
        }
    }
}
