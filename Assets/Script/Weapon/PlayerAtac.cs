using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAtac : WeaponGeneral
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private PleayrMove playerMove;
    [SerializeField] private Animator animator;
    public int attackIndex = 0;
    private float damageMult = 1;
    
    protected override void Attack()
    {
        animator.SetTrigger("Attack");
        animator.SetInteger("AttackNum", attackIndex);
        attackObject.GetComponent<WeaponHitBox>().Damage = damage * damageMult;
        attackIndex++;
        if (attackIndex == 3)
        {
            playerMove.Dash();
            attackIndex = 0;
        }
       
    }
    

    public void AddDamage(float damage)
    {
        damageMult += damage;
    }
}
