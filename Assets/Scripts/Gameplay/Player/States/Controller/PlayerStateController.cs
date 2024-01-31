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
        private PlayerController controller;

        [SerializeField]
        private PlayerInputEventChannelSO inputEventChannel;

        [SerializeField]
        private PlayerSettingsSO playerSettings;

        //-- STATES
        public MoveState MoveState;
        public DodgeState DodgeState;
        public AimState AimState;

        //-- CACHED REFERENCES
        private IGameplayState currentState;

        private void Awake()
        {
            GameplayStateConfig config = new()
            {
                stateController = this,
                playerController = controller,
                inputChannel = inputEventChannel
            };
            MoveState = new(config);
            DodgeState = new(config);
            AimState = new(config);

            ChangeState(MoveState);

            inputEventChannel.OnAimPerformed.AddListener(EnterExitAim);
            inputEventChannel.OnDodgePerformed.AddListener(Dodge);
        }

        private void Update()
        {
            currentState.PerformState();
        }

        public void ChangeState(IGameplayState newState)
        {
            currentState?.ExitState();
            newState.EnterState();
            currentState = newState;
        }

        //-- INPUT HANDLING
        public void EnterExitAim(CallbackContext context)
        {
            if (currentState != AimState)
            {
                ChangeState(AimState);
            }
            else
            {
                ChangeState(MoveState);
            }
        }

        public void Dodge(CallbackContext context)
        {
            if ((currentState != DodgeState) && (inputEventChannel.MoveInput != Vector2.zero))
            {
                ChangeState(DodgeState);
            }
        }
    }
}