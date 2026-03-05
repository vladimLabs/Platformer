using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{
    [SerializeField] private Vector2 dir;
    [SerializeField] private float damage;
    private ObjectPooler pooler;
    private string poolName;
    void Awake()
    {
        poolName = gameObject.name.Replace("(Clone)", "").Trim();
    }
    private void Update()
    {
        transform.Translate(dir * Time.deltaTime );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().GetDamage(damage);
            ReturnToPool();
        }
        if (collision.CompareTag("Obstacle"))
        {
            ReturnToPool();
        }
    }

    public void OnObjectSpawn()
    {
        throw new System.NotImplementedException();
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
