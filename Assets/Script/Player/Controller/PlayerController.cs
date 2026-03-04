using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerDash dash;
    [SerializeField] private PlayerWallMechanics wallMechanics;
    [SerializeField] private PlayerAnimation animationController;
    [SerializeField] private PlayerFlip flipController;

    private PlayerInputActions inputActions;
    private Vector2 moveInput;
    private bool isJumpPressed;
    private bool isJumpHeld;
    private bool isDashPressed;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        InitializeComponents();
        SetupInputCallbacks();
    }

    private void InitializeComponents()
    {
        if (movement == null) movement = GetComponent<PlayerMovement>();
        if (dash == null) dash = GetComponent<PlayerDash>();
        if (wallMechanics == null) wallMechanics = GetComponent<PlayerWallMechanics>();
        if (animationController == null) animationController = GetComponent<PlayerAnimation>();
        if (flipController == null) flipController = GetComponent<PlayerFlip>();
    }

    private void SetupInputCallbacks()
    {
        // Move
        inputActions.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        // Jump
        inputActions.Player.Jump.started += ctx => isJumpPressed = true;
        inputActions.Player.Jump.performed += ctx => isJumpHeld = true;
        inputActions.Player.Jump.canceled += ctx => 
        {
            isJumpPressed = false;
            isJumpHeld = false;
        };

        // Dash
        inputActions.Player.Dash.performed += ctx => isDashPressed = true;
        inputActions.Player.Dash.canceled += ctx => isDashPressed = false;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        if (!wallMechanics.IsWallJumping)
        {
            movement.ProcessMovement(moveInput.x);
        }

        HandleJump();
        HandleDash();
        
        flipController.UpdateFlip(movement.GetVelocity().x);
        animationController.UpdateAnimations(movement, wallMechanics);
    }

    private void HandleJump()
    {
        if (isJumpPressed)
        {
            if (movement.IsGrounded())
            {
                movement.Jump();
            }
            else if (wallMechanics.CanWallJump())
            {
                movement.WallJump(wallMechanics.GetWallDirection());
                wallMechanics.StartWallJump();
            }
            isJumpPressed = false;
        }
    }

    private void HandleDash()
    {
        if (isDashPressed && dash.CanDash())
        {
            if (movement.IsGrounded())
            {
                dash.PerformGroundDash();
            }
            else
            {
                dash.PerformAirDash();
            }
            isDashPressed = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        wallMechanics.HandleWallRunStay(other, isJumpHeld);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        wallMechanics.HandleWallRunExit(other);
    }
}