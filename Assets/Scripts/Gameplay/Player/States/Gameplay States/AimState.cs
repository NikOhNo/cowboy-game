using Assets.Scripts.Events;
using Assets.Scripts.Gameplay.Player.Movement_States;
using Assets.Scripts.Gameplay.Weapons;
using UnityEngine;


namespace Assets.Scripts.Gameplay.Player.States.Gameplay_States
{
    public class AimState : GameplayStateBase
    {
        

        //-- GAMEPLAY STATE
        public override bool CanInterrupt { get; protected set; } = true;

        public AimState(GameplayStateConfig config) : base(config)
        {
        }

        public override void EnterState()
        {
        }

        public override void PerformState()
        {            
            // TODO: apply modifier for aiming movement
        }

        public override void ExitState()
        {
            
        }
    }
}