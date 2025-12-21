using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject attacker;
    [SerializeField] private Animator animator;
    [SerializeField] private int attackCombo;
    private int currentAttack;
    private float detectionDistance = 5f;
    private bool startAttack = true;

    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance <= detectionDistance && startAttack == true)
            {
                StartCoroutine(FarmAttack());
            }
        }
    }
    
    private IEnumerator FarmAttack()
    {
        startAttack = false;
        attacker.SetActive(true);
        animator.SetInteger("AttackNum", Random.Range(0, attackCombo));
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(0.1f);
        attacker.SetActive(false);
        yield return new WaitForSeconds(2f);
        startAttack = true;
    }
}
