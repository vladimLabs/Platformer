using System.Collections;
using UnityEngine;

public class PlayerRevolver : WeaponGeneral
{
    [SerializeField] private Transform spp;
    [SerializeField] private Transform rotationPoint;
    [SerializeField] private int maxAmmo;
    private int curentAmmo = 0;
    private bool reloadingARevolver = true;
    [SerializeField] private UIAmmo text;
    [SerializeField] public int bankAmmo;

    private void Start()
    {
        curentAmmo = maxAmmo;
        text.UpdateUI(curentAmmo, bankAmmo);
    }

    protected override void Update()
    {
        base.Update();
        if (reloadingARevolver && Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reloading());
        }

    }

    protected override void Attack()
    {
        if (reloadingARevolver && curentAmmo > 0)
        {
            base.Attack();
            Instantiate(attackObject, spp.position, rotationPoint.rotation);
            curentAmmo -= 1;

            text.UpdateUI(curentAmmo, bankAmmo);
            //if (reloadingARevolver && curentAmmo == 0)
            //{
            //    StartCoroutine(Reloading());
            //}
        }
    }

    public void AddAmmo(int ammo)
    {
        bankAmmo += ammo;
        text.UpdateUI(curentAmmo, bankAmmo);
    }

    IEnumerator Reloading()
    {
        if ( bankAmmo > 0 )
        {
            int a = maxAmmo - curentAmmo;

            reloadingARevolver = false;

            for (int i = 0; i < a; i++)
            {
                yield return new WaitForSeconds(0.5f);
                curentAmmo += 1;
                bankAmmo -= 1;
                text.UpdateUI(curentAmmo, bankAmmo);
            }

            reloadingARevolver = true;
        }
    }
}
