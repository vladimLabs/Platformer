using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : CreatureHealth
{
    [SerializeField] private HealthUI healthUI;
    
    public bool isDeflecting = false;

    private void Start()
    {
        health = PlayerPrefs.GetInt("HP");
    }

    public override void GetDamage(float damage)
    {
        if(isDeflecting) return;
        base.GetDamage(damage);
        healthUI.ChangeHeartsCount(damage * -1);
    }

    public override void GetHeal(float heal)
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

