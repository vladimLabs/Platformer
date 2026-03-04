using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string groundedParam = "IsGrounded";
    [SerializeField] private string walkingParam = "IsWalking";
    [SerializeField] private string jumpTrigger = "Jump";
    [SerializeField] private string dashTrigger = "Dash";
    [SerializeField] private string airDashTrigger = "AirDash";

    private void Awake()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    public void UpdateAnimations(PlayerMovement movement, PlayerWallMechanics wallMechanics)
    {
        if (animator == null) return;

        animator.SetBool(groundedParam, movement.IsGrounded());
        animator.SetBool(walkingParam, Mathf.Abs(movement.GetVelocity().x) > 0.1f);
    }

    public void TriggerJump() => animator?.SetTrigger(jumpTrigger);
    public void TriggerDash() => animator?.SetTrigger(dashTrigger);
    public void TriggerAirDash() => animator?.SetTrigger(airDashTrigger);
}