using UnityEngine;

public abstract class EnemyAttackGeneral : MonoBehaviour
{
   [HideInInspector] public bool startAttack = true;
   protected bool canAttack = true;
   
   public void SetCanShoot(bool value)
   {
      canAttack = value;
   }
}
