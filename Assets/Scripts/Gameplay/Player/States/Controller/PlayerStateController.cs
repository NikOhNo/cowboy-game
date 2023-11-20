using System.Collections;
using Unity.Android.Gradle;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.InputSystem.XR;
using Assets.Scripts.Gameplay.Player.States.Gameplay_States;
using UnityEngine.InputSystem;
using Assets.Scripts.Gameplay.Weapons;

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
        private PlayerController controller;

        //-- PROPERTIES
        public PlayerSettings PlayerSettings => playerSettings;
        public Vector2 MoveInput = new();
        public Vector2 SmoothedInputVector = new();
        public Vector2 MousePos = new();
        public Weapon CurrWeapon => currWeapon;

        //-- STATES
        public readonly MoveState MoveState = new();
        public readonly DodgeState DodgeState = new();
        public readonly AimState AimState = new();

        //-- CACHED REFERENCES
        private IGameplayState currState;
        [SerializeField] private Weapon currWeapon;     // TODO: Have curr weapon be determined by an outside source (not assigned in inspector)

        private PlayerInputActions playerInputActions;
        private Vector2 smoothInputVelocity;

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

            PivotGunToMouse();

            currState.PerformState();
        }

        public void ChangeState(IGameplayState newState)
        {
            currState?.ExitState();
            newState.EnterState(this, controller);
            currState = newState;
        }

        //-- HELPERS
        private void PivotGunToMouse()
        {
            Vector2 mousePos = MousePos;
            Transform gunPivot = controller.gunPivot;

            var mousePositionZ = Camera.main.farClipPlane;
            var mouseScreenPos = new Vector3(mousePos.x, mousePos.y, mousePositionZ);
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

            Vector3 targetDirection = mouseWorldPos - gunPivot.position;

            float rotationZ = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
            gunPivot.rotation = Quaternion.Euler(0f, 0f, rotationZ + 270);
        }

        //-- INPUT HANDLING
        public void EnterAim(CallbackContext context)
        {
            if (context.performed)
            {
                if (currState != AimState)
                {
                    ChangeState(AimState);
                }
                else
                {
                    ChangeState(MoveState);
                }
            }
        }

        public void Fire(CallbackContext context)
        {
            if (context.performed)
            {
                if (currState is AimState aimState)
                {
                    aimState.AimFireWeapon();
                }
                else if (currState is MoveState moveState)
                {
                    moveState.FireWeapon();
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
            MousePos = Mouse.current.position.ReadValue();
        }
    }
}