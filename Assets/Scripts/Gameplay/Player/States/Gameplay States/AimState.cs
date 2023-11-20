using Assets.Scripts.Gameplay.Player.Movement_States;
using Assets.Scripts.Gameplay.Weapons;
using UnityEngine;


namespace Assets.Scripts.Gameplay.Player.States.Gameplay_States
{
    public class AimState : GameplayStateBase
    {
        float elapsedAimTime = 0f;
        float currAccuracy;

        Weapon weapon;

        //-- GAMEPLAY STATE
        public override bool CanInterrupt { get; protected set; } = true;

        public override void EnterState(PlayerStateController stateController, PlayerController playerController)
        {
            base.EnterState(stateController, playerController);

            weapon = stateController.CurrWeapon;
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
            weapon.Fire(currAccuracy);
            ResetAim();
        }

        //-- HELPERS
        private float GetCurrAccuracy()
        {
            return Mathf.Lerp(0f, weapon.Settings.HipFireAccuracyDegree, elapsedAimTime / weapon.Settings.TimeToAim);
        }

        private void ResetAim()
        {
            elapsedAimTime = 0f;
            currAccuracy = weapon.Settings.HipFireAccuracyDegree;
        }
    }
}