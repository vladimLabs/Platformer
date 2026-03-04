using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossAttack1 : EnemyAttackGeneral
{
    [SerializeField] private float fireRate = 1f; 
    [SerializeField] private Transform firePoint; 
    [SerializeField] private GameObject bulletPrefab; 
    [SerializeField] private Transform rotationPart;
    [SerializeField] private float offset;
    [SerializeField] private float detectionRadius = 5f;
    
    [SerializeField] private ObjectPooler objectPooler;
    [SerializeField] private float shootCount;
    [SerializeField] float spreadAmount = 5f; 
    
    [SerializeField] private Transform player;
    private bool playerInRange = false;
    private float fireTimer = 0f;

    private bool isShot = false;

    private void Start()
    {
        startAttack = false;
    }

    private void Update()
    {
        if (startAttack)
        {
            StartCoroutine(ShootLine());
            startAttack = false;
            print("attack 1");
        }
    }


    private void ShootFireRage()
    {
        if (bulletPrefab == null || firePoint == null) return;
        
        float randomSpread = Random.Range(-spreadAmount, spreadAmount);

        Quaternion spreadRotation = rotationPart.rotation * Quaternion.Euler(0, 0, randomSpread);

        GameObject bullet = objectPooler.GetFromPool(
            bulletPrefab.name, 
            firePoint.position, 
            spreadRotation
        );

    }

    IEnumerator ShootLine()
    {
        isShot = true;
        yield return new WaitForSeconds(fireRate);
        for (int i = 0; i < shootCount; i++)
        {
            yield return new WaitForSeconds(0.4f);
            ShootFireRage();
        }

        isShot = false;
    }
}
