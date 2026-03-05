using System.Collections;
using UnityEngine;

public class BossAttack2 : EnemyAttackGeneral
{
    [SerializeField] private GameObject laser;
    [SerializeField] private BossAim aim;
    [SerializeField] private Animator animator;
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
            animator.SetTrigger("Attack");
            animator.SetInteger("AttackNum", 1);
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
