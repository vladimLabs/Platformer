using UnityEngine;

public class Attack2 : IAttack
{
    private LayerMask mask;
    private float size = 4;
    private float damage = 2;
    
    public void Attack(LayerMask enemyLayerMask, GameObject attackObject, PleayrMove playerMove)
    {
        mask = enemyLayerMask;
        Debug.Log("Attack 1");
        
        // Получаем направление атаки (right в 2D)
        Vector2 direction = attackObject.transform.right;
        
        // Используем Physics2D.Raycast для 2D
        RaycastHit2D hit = Physics2D.Raycast(
            attackObject.transform.position, 
            direction, 
            size, 
            mask
        );
        
        if (hit.collider != null)
        {
            // Визуализация луча
            Debug.DrawRay(
                attackObject.transform.position, 
                direction * hit.distance, 
                Color.yellow, 
                1
            );
            
            // Получаем компонент здоровья врага
            EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.GetDamage(damage);
                Debug.Log("Did Hit");
            }
        }
        else
        {
            // Визуализация луча, если ничего не попало
            Debug.DrawRay(
                attackObject.transform.position, 
                direction * size, 
                Color.white, 
                1
            );
        }
    }
}

