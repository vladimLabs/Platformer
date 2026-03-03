using System;
using System.Collections;
using UnityEngine;

public class PlayerDeflect : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    [SerializeField] private PlayerHealth playerHealth;

    [SerializeField] private float reloadTime;

    [SerializeField] private float deflectTime;

    public bool isDeflecting;
    
    private bool canDeflect;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && !isDeflecting)
        {
            isDeflecting = true;
            StartCoroutine(Deflecting());
            UpdateDeflectStatus();
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            StopAllCoroutines();
            animator.SetBool("isDeflecting", false);
            isDeflecting = false;
            UpdateDeflectStatus();
            StartCoroutine(ReloadDeflect());
        }
    }

    IEnumerator Deflecting()
    {
        animator.SetBool("isDeflecting", true);
        yield return new WaitForSeconds(deflectTime);
        animator.SetBool("isDeflecting", false);
        isDeflecting = false;
        UpdateDeflectStatus();
        StartCoroutine(ReloadDeflect());
    }

    IEnumerator ReloadDeflect()
    {
        isDeflecting = false;
        canDeflect = false;
        yield return new WaitForSeconds(reloadTime);
        canDeflect = true;
        
    }

    private void UpdateDeflectStatus()
    {
        playerHealth.isDeflecting = isDeflecting;
    }
}
