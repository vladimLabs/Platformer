using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossAttackController : EnemyAttackGeneral
{
    [SerializeField] private float delayBetweenAttacks;

    [SerializeField] private EnemyAttackGeneral[] attack;
    
    private bool isDead = false;
    private void Update()
    {
        if (!startAttack && !isDead)
        {
            EndAttack();
            isDead = true;
            print("End");
        }
    }

    IEnumerator Attacking()
    {
        attack[Random.Range(0, attack.Length)].startAttack = true;
        yield return new WaitForSeconds(delayBetweenAttacks);
        StartCoroutine(Attacking());
    }

    public void StartAttack()
    {
        StartCoroutine(Attacking());
    }

    public void EndAttack()
    {
        StopAllCoroutines();
        foreach (var attacks in attack)
        {
            attacks.StopAllCoroutines();
        }
    }
}
