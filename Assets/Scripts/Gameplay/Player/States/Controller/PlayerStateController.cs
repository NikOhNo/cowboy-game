using System.Collections;
using Unity.Android.Gradle;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.InputSystem.XR;
using Assets.Scripts.Gameplay.Player.States.Gameplay_States;
using Assets.Scripts.Gameplay.Player.Movement_States;

namespace Assets.Scripts.Gameplay.Player
{
    public class PlayerStateController : MonoBehaviour
    {
        //-- SERIALIZED FIELDS
        [SerializeField]
        private PlayerSettings playerSettings;

        [SerializeField]
        private float smoothInputSpeed = .2f;

        [SerializeField]
        private PlayerController playerController;

        //-- PROPERTIES
        public PlayerSettings PlayerSettings => playerSettings;
        public Vector2 MoveInput = new();
        public Vector2 SmoothedInputVector = new();
        public Vector2 MousePos = new();

        //-- STATES
        public readonly MoveState MoveState = new();
        public readonly DodgeState DodgeState = new();
        public readonly AimState AimState = new();

        //-- CACHED REFERENCES
        private IGameplayState currState;

        private PlayerInputActions playerInputActions;
        private Vector2 smoothInputVelocity;

        private PlayerController controller;

        private void Awake()
        {
            playerInputActions = new();
            playerInputActions.PlayerBattle.Enable();

            ChangeState(MoveState);
        }

        private void Update()
        {
            GetMoveInput();
            GetMousePosition();
            currState.PerformState();
        }

        public void ChangeState(IGameplayState newState)
        {
            currState?.ExitState();
            newState.EnterState(this, controller);
            currState = newState;
        }


        //-- INPUT HANDLING

        public void EnterAim(CallbackContext context)
        {
            if (context.performed)
            {
                ChangeState(AimState);
            }
        }

        public void Fire(CallbackContext context)
        {
            if (context.performed)
            {
                if (currState is AimState aimState)
                {
                    // Tell aim state to fire

                }
                else if (currState is MoveState moveState)
                {
                    
                }
            }
        }

        public void Dodge(CallbackContext context)
        {
            if (currState != DodgeState && context.performed && MoveInput != Vector2.zero)
            {
                ChangeState(DodgeState);
            }
        }

        private void GetMoveInput()
        {
            MoveInput = playerInputActions.PlayerBattle.Move.ReadValue<Vector2>();
            // Calculate Smoothed Input
            SmoothedInputVector = Vector2.SmoothDamp(SmoothedInputVector, MoveInput, ref smoothInputVelocity, smoothInputSpeed);
        }

        private void GetMousePosition()
        {
            MousePos = playerInputActions.PlayerBattle.Look.ReadValue<Vector2>();
        }
    }
}