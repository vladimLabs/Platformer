using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAtac : WeaponGeneral
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float hitBoxLifeTime;
    [SerializeField] private PleayrMove playerMove;
    private List<IAttack> attacks = new List<IAttack>();
    private IAttack currentAttack;
    private int attackIndex = 0;

    private void Start()
    {
        attacks.Add(new Attack1());
        attacks.Add(new Attack2());
        attacks.Add(new Attack3());
        currentAttack = attacks[0];
        print(currentAttack);
    }
    protected override void Attack()
    {
        currentAttack.Attack(layerMask, attackOdject, playerMove);
        attackIndex++;
        if (attackIndex == attacks.Count)
        {
            attackIndex = 0;
        }
        currentAttack = attacks[attackIndex];

    }
}
