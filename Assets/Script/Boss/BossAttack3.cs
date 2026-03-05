using System.Collections;
using UnityEngine;

public class BossAttack3 : EnemyAttackGeneral
{
    [SerializeField] private float fireRate = 1f; 
    [SerializeField] private Transform firePoint; 
    [SerializeField] private GameObject bulletPrefab; 
    
    [SerializeField] private ObjectPooler objectPooler;
    [SerializeField] private float shootCount;
    [SerializeField] private Animator animator;
    
    private bool playerInRange = false;
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
            print("attack 3");
        }
    }


    private void ShootFireRage()
    {
        if (bulletPrefab == null || firePoint == null) return;
        animator.SetTrigger("Attack");
        animator.SetInteger("AttackNum", 1);
        GameObject bullet = objectPooler.GetFromPool(
            bulletPrefab.name, 
            firePoint.position, 
            Quaternion.identity
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
