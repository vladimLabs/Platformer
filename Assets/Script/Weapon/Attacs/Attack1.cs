using System.Collections;
using UnityEngine;

public class Attack1 : IAttack
{
    public float AttackDelay = 0.3f;
    private LayerMask mask;
    private float size = 2;
    public float damage = 2;
    private float delay;
    
    public override void Attack(LayerMask enemyLayerMask, GameObject attackObject, PleayrMove playerMove, float damageMult)
    {
        mask = enemyLayerMask;
        Debug.Log("Attack 1");
        
      
    }
}

