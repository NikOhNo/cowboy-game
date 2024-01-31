using Assets.Scripts.Gameplay.Player;
using Assets.Scripts.Gameplay.Player.Movement_States;
using Assets.Scripts.Gameplay.Player.States.Gameplay_States;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class DodgeState : GameplayStateBase
{
    //-- PROPERTIES
    public override bool CanInterrupt { get; protected set; } = false;

    //-- Helper Variables
    private float elapsedTime = 0f;
    private Vector2 dodgeVelocity;

    public DodgeState(GameplayStateConfig config) : base(config)
    {
    }

    public override void EnterState()
    {
        //dodgevelocity = inputhandler.moveinput * dodgespeed;
        //controller.rb2d.velocity = dodgevelocity;
        //elapsedtime = 0f;
    }

    public override void ExitState()
    {
        // TODO: adjust animators and wrap up anything else associated with state
        //inputHandler.MoveInput = Vector2.zero;
        //inputHandler.SmoothedInputVector = Vector2.zero;
    }

    public override void PerformState()
    {
        //controller.rb2D.velocity = dodgeVelocity;
        //elapsedTime += Time.deltaTime;

        //if (elapsedTime >= DodgeTime)
        //{
        //    stateController.ChangeState(stateController.MoveState);
        //}
    }
}
