
using System.Collections;
using UnityEngine;

public abstract class IAttack
{
    public float AttackDelay;
    public float damage;

    public virtual void Attack(LayerMask enemyLayerMask, GameObject attackObject, PleayrMove playerMove, float damageMult)
    {

    }
}