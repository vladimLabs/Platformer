using System.Collections;
using UnityEngine;

public abstract class WeaponGeneral : MonoBehaviour
{
    [SerializeField] protected GameObject attackOdject;
    [SerializeField] protected float damage;
    [SerializeField] protected float timeBetweenAttacks;

    protected bool canAttack = true;

    protected virtual IEnumerator Attacking()
    {
        canAttack = false;
        Attack();
        yield return new WaitForSeconds(timeBetweenAttacks);
        canAttack = true;
    }

    protected virtual void Update()
    {
        if (canAttack && Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Attacking());
        }
    }

    protected virtual void Attack()
    {

    }
}
