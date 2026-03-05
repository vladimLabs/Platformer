using System;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] private BossAttackController bossAttack;
    [SerializeField] private BossMovement bossMovement;
    private bool isStarted = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isStarted)
        {
            bossAttack.StartAttack();
            bossMovement.StartMovement();
            isStarted = true;
        }
    }
}
