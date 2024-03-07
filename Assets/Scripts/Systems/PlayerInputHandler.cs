using Assets.Scripts.Gameplay.Player;
using Assets.Scripts.Gameplay.Player.States.Gameplay_States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField]
    private float smoothInputSpeed = .2f;

    //-- CACHED REFERENCES
    private Vector2 smoothInputVelocity;

    // Update is called once per frame
    void Update()
    {
        SmoothMoveInput();
        GetMousePosition();
    }

    private void SmoothMoveInput()
    {
        // Calculate Smoothed Input
        //smoothInputVelocity = Vector2.SmoothDamp(smoothInputVelocity, MoveInput, ref smoothInputVelocity, smoothInputSpeed);
    }

    private void GetMousePosition()
    {
        //MousePosition = Mouse.current.position.ReadValue();
    }
}
