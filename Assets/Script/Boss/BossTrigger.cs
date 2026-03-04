using System;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] private BossAttackController bossAttack;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bossAttack.StartAttack();
        }
    }
}
