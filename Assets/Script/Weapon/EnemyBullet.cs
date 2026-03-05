using UnityEngine;

public class EnemyBullet : MonoBehaviour, IPooledObject
{
    [SerializeField] private Vector2 dir;
    
    [SerializeField] private int damage;

    [SerializeField] private bool destroyByObstacles;
    
    public ObjectPooler objectPooler;
    
    private ObjectPooler pooler;
    private string poolName;
    void Update()
    {
        transform.Translate(dir * Time.deltaTime );
    }
    void Awake()
    {
        poolName = gameObject.name.Replace("(Clone)", "").Trim();
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
            ReturnToPool();
        }

        if (destroyByObstacles)
        {
            if (collision.CompareTag("Obstacle"))
            {
                ReturnToPool();
            }
        }
    }
    void ReturnToPool()
    {
        var isActive = false;
        
        if (pooler != null)
        {
            pooler.ReturnToPool(poolName, gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnObjectSpawn(ObjectPooler pool)
    {
        pooler = pool;
    }
}
