using Assets.Scripts.Gameplay.Player.Movement_States;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Player.States.Gameplay_States
{
    public class AimState : GameplayStateBase
    {
        float elapsedAimTime = 0f;

        public override void EnterState(PlayerStateController stateController, PlayerController playerController)
        {
            base.EnterState(stateController, playerController);

            elapsedAimTime = 0f;
        }

        public override void PerformState()
        {
            // TODO: 
            // * Walk slow
            // * Aim at cursor
            // * Click to fire
            elapsedAimTime += Time.deltaTime;
            playerController.gunPivot.rotation = new Quaternion(0, 0, , 0);
        }

        public override void ExitState()
        {
            elapsedAimTime = 0;
            throw new System.NotImplementedException();
        }
    }
}