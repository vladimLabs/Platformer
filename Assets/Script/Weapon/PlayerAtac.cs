using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAtac : WeaponGeneral
{
    [SerializeField] private float hitBoxLifeTime;
    private IAttack currentAttack;

    private void Start()
    {
        currentAttack = new Attack1();
    }
    protected override void Attack()
    {
        Debug.Log("Attack");
        currentAttack.Attack(hitBoxLifeTime, attackOdject);
    }
}
