using Assets.Scripts.Gameplay.Player;
using Assets.Scripts.Gameplay.Player.Movement_States;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class MoveState : GameplayStateBase
{
    private float MoveSpeed => stateController.PlayerSettings.MoveSpeed;

    public override bool CanInterrupt { get; protected set; } = true;

    public override void EnterState(PlayerStateController stateController, PlayerController playerController)
    {
        base.EnterState(stateController, playerController);
    }

    public override void ExitState()
    {

    }

    public override void PerformState()
    {
        // Calculate velocity after modifiers
        Vector2 newVeloctiy = stateController.SmoothedInputVector * MoveSpeed;

        // Update velocity
        playerController.rb2D.velocity = newVeloctiy;
    }

    public void FanHammer()
    {

    }
}
