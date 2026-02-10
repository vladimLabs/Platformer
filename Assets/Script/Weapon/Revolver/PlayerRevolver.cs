using System.Collections;
using UnityEngine;

public class PlayerRevolver : WeaponGeneral
{
    [SerializeField] private Transform spp;
    [SerializeField] private Transform rotationPoint;
    [SerializeField] private Animator animator;
    [SerializeField] private int maxAmmo;
    [SerializeField] private ParticleSystem shootSFX;
    [SerializeField] private UIAmmo text;
    [SerializeField] public int bankAmmo;
    
    [SerializeField] private ObjectPooler objectPooler;
    [SerializeField] private GameObject bulletPrefab;
    
    private int curentAmmo = 0;
    private bool reloadingARevolver = true;

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
            
            GameObject bullet = objectPooler.GetFromPool(
                bulletPrefab.name, 
                spp.position, 
                rotationPoint.rotation
            );
            
            curentAmmo -= 1;
            animator.SetTrigger("Shoot");
            text.UpdateUI(curentAmmo, bankAmmo);
            shootSFX.Play();
        }
    }

    public void AddAmmo(int ammo)
    {
        bankAmmo += ammo;
        text.UpdateUI(curentAmmo, bankAmmo);
    }

    IEnumerator Reloading()
    {
        if (bankAmmo > 0)
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