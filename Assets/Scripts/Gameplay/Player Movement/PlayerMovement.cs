using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 7.5f;

    [SerializeField]
    private float smoothInputSpeed = .2f;

    [SerializeField]
    private float dodgeRollTime = 0.7f;

    [SerializeField]
    private float dodgeSpeed = 10f;

    public bool CanMove { get; private set; } = true;
    public bool Dodging { get; private set; } = false;

    private Rigidbody2D rigidbody2d;
    private PlayerInputActions playerInputActions;
    private Vector2 moveInput;
    private Vector2 smoothedInputVector;
    private Vector2 smoothInputVelocity;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        playerInputActions = new();
        playerInputActions.PlayerBattle.Enable();
    }

    private void FixedUpdate()
    {
        MovePlayer(); 
    }

    IEnumerator PerformDodge()
    {
        CanMove = false;
        Dodging = true;
        smoothedInputVector = Vector2.zero;

        rigidbody2d.velocity = moveInput * dodgeSpeed;
        yield return new WaitForSeconds(dodgeRollTime);

        CanMove = true;
        Dodging = false;
    }

    //-- INPUT HANDLING

    public void MovePlayer()
    {
        if (CanMove)
        {
            // Calculate Input
             moveInput = playerInputActions.PlayerBattle.Move.ReadValue<Vector2>();
            smoothedInputVector = Vector2.SmoothDamp(smoothedInputVector, moveInput, ref smoothInputVelocity, smoothInputSpeed);

            // Calculate velocity after modifiers
            Vector2 newVeloctiy = smoothedInputVector * moveSpeed;

            // Update velocity
            rigidbody2d.velocity = newVeloctiy;
        }
    }

    public void Dodge(CallbackContext context)
    {
        if (context.performed && moveInput != Vector2.zero)
        {
            StartCoroutine(PerformDodge());
        }
    }
}
