using System.Collections;
using UnityEngine;

public class Attack2 : IAttack
{
    public float AttackDelay = 0.45f;
    private LayerMask mask;
    private float size = 4;
    public float damage = 2;
    
    public override void Attack(LayerMask enemyLayerMask, GameObject attackObject, PleayrMove playerMove, float damageMult)
    {
        mask = enemyLayerMask;
        Debug.Log("Attack 2");
      
    }
}

