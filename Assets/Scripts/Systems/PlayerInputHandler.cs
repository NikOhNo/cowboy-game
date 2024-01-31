using Assets.Scripts.Gameplay.Player;
using Assets.Scripts.Gameplay.Player.States.Gameplay_States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputHandler : MonoBehaviour
{
    //-- SERIALIZED FIELDS
    [SerializeField]
    private PlayerInputEventChannelSO inputEventChannel;

    [SerializeField]
    private float smoothInputSpeed = .2f;

    //-- CACHED REFERENCES
    private Vector2 smoothInputVelocity;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        SmoothMoveInput();
        GetMousePosition();
    }

    //-- INPUT HANDLING
    public void Move(CallbackContext context)
    {
        inputEventChannel.MoveInput = context.ReadValue<Vector2>();
    }

    public void Aim(CallbackContext context)
    {
        if (context.performed)
        {
            inputEventChannel.OnAimPerformed.Invoke(context);
        }
    }

    public void Fire(CallbackContext context)
    {
        if (context.performed)
        {
            inputEventChannel.OnFirePerformed.Invoke(context);
        }
    }

    public void Dodge(CallbackContext context)
    {
        if (context.performed)
        {
            inputEventChannel.OnDodgePerformed.Invoke(context);
        }
    }

    private void SmoothMoveInput()
    {
        // Calculate Smoothed Input
        inputEventChannel.SmoothedInputVector = Vector2.SmoothDamp(inputEventChannel.SmoothedInputVector, inputEventChannel.MoveInput, ref smoothInputVelocity, smoothInputSpeed);
    }

    private void GetMousePosition()
    {
        inputEventChannel.MousePosition = Mouse.current.position.ReadValue();
    }
}
