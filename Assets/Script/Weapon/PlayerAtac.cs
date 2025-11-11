using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAtac : WeaponGeneral
{
    [SerializeField] private float hitBoxLifeTime;

    protected override void Attack()
    {
        StartCoroutine(HitBoxDelay());
    }

    private IEnumerator HitBoxDelay()
    {
        attackOdject.SetActive(true);
        yield return new WaitForSeconds(hitBoxLifeTime);
        attackOdject.SetActive(false);
    }
}
