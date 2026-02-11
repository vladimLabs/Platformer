using System;
using System.Collections;
using UnityEngine;

public class DroneAttack : EnemyAttackGeneral
{
    [SerializeField] private float fireRate = 1f; 
    [SerializeField] private Transform firePoint; 
    [SerializeField] private GameObject bulletPrefab; 
    [SerializeField] private Transform rotationPart;
    [SerializeField] private float offset;
    [SerializeField] private float detectionRadius = 5f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private ObjectPooler objectPooler;
    [SerializeField] private Transform player;
    private bool playerInRange = false;
    private float fireTimer = 0f;

    private bool isShot = false;
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
    
    private void Update()
    {
        playerInRange = Physics2D.OverlapCircle(transform.position, detectionRadius, layerMask);
        if (playerInRange)
        {
            AimAtPlayer();
            if (!isShot) StartCoroutine(ShootLine());
        }
    }
    
    private void AimAtPlayer()
    {
        if (rotationPart == null) return;
        
        Vector2 direction = player.position - rotationPart.position;
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        rotationPart.rotation = Quaternion.Euler(0f, 0f, angle + offset);
    }
    
    private void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;
        
        GameObject bullet = objectPooler.GetFromPool(
            bulletPrefab.name, 
            firePoint.position, 
            rotationPart.rotation
        );

    }

    IEnumerator ShootLine()
    {
        isShot = true;
        print("shoot");
        if (playerInRange)
        {
            yield return new WaitForSeconds(fireRate);
            for (int i = 0; i < 5; i++)
            {
                yield return new WaitForSeconds(0.4f);
                Shoot();
            }
        }

        isShot = false;
    }
}