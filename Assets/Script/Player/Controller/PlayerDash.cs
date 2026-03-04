using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [Header("Dash Settings")]
    [SerializeField] private float dashForce = 15f;
    [SerializeField] private float dashCooldown = 0.5f;
    [SerializeField] private float dashDuration = 0.2f;
    
    [Header("References")]
    [SerializeField] private Transform orientation;
    [SerializeField] private PlayerWallMechanics wallMechanics;
    [SerializeField] private PlayerAnimation animationController;

    private bool canDash = true;
    private bool isDashing;

    public bool CanDash() => canDash && !isDashing;

    public void PerformGroundDash()
    {
        StartCoroutine(DashCoroutine(dashForce));
        animationController.TriggerDash();
    }

    public void PerformAirDash()
    {
        StartCoroutine(DashCoroutine(dashForce * 1.5f));
        animationController.TriggerAirDash();
    }

    private IEnumerator DashCoroutine(float force)
    {
        canDash = false;
        isDashing = true;

        wallMechanics.StartWallJump();
        
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(orientation.right * force, ForceMode2D.Impulse);

        yield return new WaitForSeconds(dashDuration);
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}