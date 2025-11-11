using UnityEngine;
using UnityEngine.SceneManagement;

public class PleayrHealth : CreatureHealth
{
    [SerializeField] private HealthUI healthUI;
    public override void GetDamage(int damage)
    {
        base.GetDamage(damage);
        healthUI.ChangeHeartsCount(damage * -1);
    }

    public override void GetHeal(int heal)
    {
        base.GetHeal(heal);
        healthUI.ChangeHeartsCount(heal);
    }


    protected override void Death()
    {
        base.Death();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

