using System.Collections;
using UnityEngine;

public class BossAttack2 : EnemyAttackGeneral
{
    [SerializeField] private GameObject laser;
    [SerializeField] private BossAim aim;
    
    private void Start()
    {
        startAttack = false;
    }

    private void Update()
    {
        if (startAttack)
        {
            StartCoroutine(ShootRay());
            print("attack 2");
            startAttack = false;
        }
    }

    IEnumerator ShootRay()
    {
        for (int i = 0; i < 3; i++)
        {
            laser.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            aim.aiming = false;
            yield return new WaitForSeconds(0.5f);
            aim.aiming = true;
            laser.SetActive(false);
            yield return new WaitForSeconds(1f);
        }
    }
}
