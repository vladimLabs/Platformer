using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossAttackController : EnemyAttackGeneral
{
    [SerializeField] private float delayBetweenAttacks;

    [SerializeField] private EnemyAttackGeneral[] attack;
    
    IEnumerator Attacking()
    {
        yield return new WaitForSeconds(delayBetweenAttacks);
        attack[Random.Range(0, attack.Length)].startAttack = true;
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
