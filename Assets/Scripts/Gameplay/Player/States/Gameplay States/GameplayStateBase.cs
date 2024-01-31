using Assets.Scripts.Gameplay.Player.States.Gameplay_States;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Player.Movement_States
{
    public abstract class GameplayStateBase : IGameplayState
    {
        protected readonly GameplayStateConfig config;
        public abstract bool CanInterrupt { get; protected set; }

        public GameplayStateBase(GameplayStateConfig config)
        {
            this.config = config;
        }

        public abstract void EnterState();
        public abstract void ExitState();
        public abstract void PerformState();
    }
}