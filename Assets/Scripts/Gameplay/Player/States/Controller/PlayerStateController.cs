using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.InputSystem.XR;

namespace Assets.Scripts.Gameplay.Player
{
    public class PlayerStateController : MonoBehaviour
    {
        //-- SERIALIZED FIELDS
        [SerializeField]
        private PlayerSettings playerSettings;
        [SerializeField]
        private float smoothInputSpeed = .2f;

        //-- PROPERTIES
        public PlayerSettings PlayerSettings => playerSettings;
        public Vector2 MoveInput = new();
        public Vector2 SmoothedInputVector = new();

        //-- STATES
        public readonly MoveState MoveState = new();
        public readonly DodgeState DodgeState = new();

        //-- CACHED REFERENCES
        private IGameplayState currState;

        private PlayerInputActions playerInputActions;
        private Vector2 smoothInputVelocity;

        private PlayerController controller;

        private void Awake()
        {
            controller = new PlayerController()
            {
                rigidbody2D = GetComponent<Rigidbody2D>(),
                animator = GetComponent<Animator>()
            };

            playerInputActions = new();
            playerInputActions.PlayerBattle.Enable();

            ChangeState(MoveState);
        }

        private void FixedUpdate()
        {
            GetMoveInput();
            currState.PerformState();
        }

        public void ChangeState(IGameplayState newState)
        {
            currState?.ExitState();
            newState.EnterState(this, controller);
            currState = newState;
        }


        //-- INPUT HANDLING

        public void GetMoveInput()
        {
            MoveInput = playerInputActions.PlayerBattle.Move.ReadValue<Vector2>();
            // Calculate Smoothed Input
            SmoothedInputVector = Vector2.SmoothDamp(SmoothedInputVector, MoveInput, ref smoothInputVelocity, smoothInputSpeed);
        }

        public void Dodge(CallbackContext context)
        {
            if (currState != DodgeState && context.performed && MoveInput != Vector2.zero)
            {
                ChangeState(DodgeState);
            }
        }
    }
}