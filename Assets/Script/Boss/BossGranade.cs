using System.Collections;
using UnityEngine;

public class BossGranade : MonoBehaviour, IPooledObject
{
    [SerializeField] private float explosionForce = 10f;      
    [SerializeField] private float explosionRadius = 5f;  
    [SerializeField] private float fuseTime = 3f;             
    [SerializeField] private float minImpulseForce = 5f;   
    [SerializeField] private float maxImpulseForce = 10f;    
    
 
    [SerializeField] private GameObject explosionEffect;     
    [SerializeField] private LayerMask damageableLayers;   
    
    private Rigidbody2D rb;
    private float countdown;
    private bool hasExploded = false;
    
     
    private ObjectPooler pooler;
    private string poolName;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        poolName = gameObject.name.Replace("(Clone)", "").Trim();
    }

    
    void ApplyRandomImpulse()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        
        float impulseForce = Random.Range(minImpulseForce, maxImpulseForce);
        rb.AddForce(randomDirection * impulseForce, ForceMode2D.Impulse);
        
    }

    void Explode()
    {
        hasExploded = true;
        
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius, damageableLayers);
        
        foreach (Collider2D nearbyObject in colliders)
        {
            CreatureHealth damageable = nearbyObject.GetComponent<CreatureHealth>();
            damageable.GetDamage(2);
        }

        ReturnToPool();
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(countdown);
        Explode();
    }
    void ReturnToPool()
    {
     
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

    
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
        countdown = fuseTime;
        ApplyRandomImpulse();
        StartCoroutine(Delay());
    }
}