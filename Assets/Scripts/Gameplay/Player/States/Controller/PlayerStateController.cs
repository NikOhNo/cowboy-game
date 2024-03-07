using System.Collections;
//using Unity.Android.Gradle;
using Unity.VisualScripting;
using UnityEngine;
using Assets.Scripts.Gameplay.Player.States.Gameplay_States;
using Assets.Scripts.Gameplay.Weapons;

namespace Assets.Scripts.Gameplay.Player
{
    public class PlayerStateController : MonoBehaviour
    {
        //-- SERIALIZED FIELDS
        [SerializeField]
        private PlayerController controller;

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
                playerController = controller
            };
            MoveState = new(config);
            DodgeState = new(config);
            AimState = new(config);

            ChangeState(MoveState);
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
        public void EnterExitAim()
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

        public void Dodge()
        {
            //  && (inputEventChannel.MoveInput != Vector2.zero) used to be in if statement removed while removing new input system
            if ((currentState != DodgeState))
            {
                ChangeState(DodgeState);
            }
        }
    }
}