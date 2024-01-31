using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Events/New Player Input Event Channel")]
public class PlayerInputEventChannelSO : ScriptableObject
{
    public Vector2 MoveInput = new();
    public Vector2 SmoothedInputVector = new();
    public Vector2 MousePosition = new();
    public UnityEvent<CallbackContext> OnAimPerformed;
    public UnityEvent<CallbackContext> OnFirePerformed;
    public UnityEvent<CallbackContext> OnDodgePerformed;
    public UnityEvent<CallbackContext> OnMovePerformed;

}
