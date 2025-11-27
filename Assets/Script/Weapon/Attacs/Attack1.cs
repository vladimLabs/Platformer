using System.Collections;
using UnityEngine;

public class Attack1 : IAttack
{
    public void Attack(float hitBoxLifeTime, GameObject attackObject)
    {
        Debug.Log("Attack 1");
        //StartCoroutine(HitBoxDelay(hitBoxLifeTime, attackObject));
    }

    //private IEnumerator HitBoxDelay(float hitBoxLifeTime, GameObject attackObject)
    //{
    //    attackObject.SetActive(true);
    //    yield return new WaitForSeconds(hitBoxLifeTime);
    //    attackObject.SetActive(false);
    //}
}
