using Assets.Scripts.Gameplay.Player.Movement_States;
using Assets.Scripts.Gameplay.Weapons;
using UnityEngine;


namespace Assets.Scripts.Gameplay.Player.States.Gameplay_States
{
    public class AimState : GameplayStateBase
    {
        private float elapsedAimTime = 0f;
        private float currAccuracy;

        //-- GAMEPLAY STATE
        public override bool CanInterrupt { get; protected set; } = true;

        public override void EnterState(PlayerStateController stateController, PlayerController playerController)
        {
            base.EnterState(stateController, playerController);

            ResetAim();
        }

        public override void PerformState()
        {
            elapsedAimTime += Time.deltaTime;
            currAccuracy = GetCurrAccuracy();
        }

        public override void ExitState()
        {
            elapsedAimTime = 0;
        }

        //-- PUBLIC FUNCTIONS
        public void AimFireWeapon()
        {
            currAccuracy = GetCurrAccuracy();
            stateController.CurrWeapon.Fire(currAccuracy);
            ResetAim();
        }

        //-- HELPERS
        private float GetCurrAccuracy()
        {
            Weapon currWeapon = stateController.CurrWeapon;
            // TODO: Debug if this is working
            return Mathf.Lerp(currWeapon.Settings.HipFireAccuracyDegree, 0f, elapsedAimTime / currWeapon.Settings.TimeToAim);
        }

        private void ResetAim()
        {
            elapsedAimTime = 0f;
            currAccuracy = stateController.CurrWeapon.Settings.HipFireAccuracyDegree;
        }
    }
}