using Assets.Scripts.Gameplay.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController
{
    readonly PlayerController playerController;

    public PlayerMoveController(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public void MoveInDirection(Vector2 direction, float speed)
    {
        // Calculate velocity after modifiers
        Vector2 newVeloctiy = direction * speed;

        // Update velocity
        playerController.rb2D.velocity = newVeloctiy;
    }
}
