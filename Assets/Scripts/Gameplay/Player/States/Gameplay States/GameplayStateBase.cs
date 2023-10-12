using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Player.Movement_States
{
    public abstract class GameplayStateBase : IGameplayState
    {
        protected PlayerStateController stateController;
        protected PlayerController playerController;

        public abstract bool CanInterrupt { get; protected set; }

        public virtual void EnterState(PlayerStateController stateController, PlayerController playerController)
        {
            this.stateController = stateController;
            this.playerController = playerController;
        }
        public abstract void ExitState();
        public abstract void PerformState();
    }
}