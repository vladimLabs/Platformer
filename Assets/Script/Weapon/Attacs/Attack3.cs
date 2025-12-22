using System.Collections;
using UnityEngine;

public class Attack3 : IAttack
{
    public float AttackDelay = 0;
    private LayerMask mask;
    private float size = 4;
    public float damage = 2;
    
    public void Attack(LayerMask enemyLayerMask, GameObject attackObject, PleayrMove playerMove, float damageMult)
    {
        mask = enemyLayerMask;
        Debug.Log("Attack 3");
        
        // Получаем направление атаки (right в 2D)
        
        playerMove.Dash();
        
    }
    
}

