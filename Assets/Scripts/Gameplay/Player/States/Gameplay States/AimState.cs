using Assets.Scripts.Gameplay.Player.Movement_States;
using UnityEngine;


namespace Assets.Scripts.Gameplay.Player.States.Gameplay_States
{
    public class AimState : GameplayStateBase
    {
        float elapsedAimTime = 0f;

        //-- GAMEPLAY STATE
        public override bool CanInterrupt { get; protected set; } = true;

        public override void EnterState(PlayerStateController stateController, PlayerController playerController)
        {
            base.EnterState(stateController, playerController);

            elapsedAimTime = 0f;
        }

        public override void PerformState()
        {
            elapsedAimTime += Time.deltaTime;
        }

        public override void ExitState()
        {
            elapsedAimTime = 0;
        }

        //-- PUBLIC FUNCTIONS
        public void FireGun()
        {

        }

        //-- HELPERS
    }
}