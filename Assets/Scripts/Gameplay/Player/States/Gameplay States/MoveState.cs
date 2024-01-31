using Assets.Scripts.Gameplay.Player;
using Assets.Scripts.Gameplay.Player.Movement_States;
using Assets.Scripts.Gameplay.Player.States.Gameplay_States;
using Assets.Scripts.Gameplay.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class MoveState : GameplayStateBase
{
    public override bool CanInterrupt { get; protected set; } = true;

    public MoveState(GameplayStateConfig config) : base(config)
    {
    }

    public override void EnterState()
    {

    }

    public override void PerformState()
    {
        //config.playerController.moveController.MoveInDirection()
    }

    public override void ExitState()
    {

    }

    public void HipFireWeapon()
    {
        Weapon currWeapon = config.weaponChannel.CurrentWeapon;

        config.weaponChannel.OnFireWeapon.Invoke(currWeapon.Settings.HipFireAccuracyDegree);
    }
}
