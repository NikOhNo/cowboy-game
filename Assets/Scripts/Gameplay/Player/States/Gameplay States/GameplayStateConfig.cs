using Assets.Scripts.Events;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Player.States.Gameplay_States
{
    public class GameplayStateConfig
    {
        public PlayerInputEventChannelSO inputChannel;
        public WeaponEventChannelSO weaponChannel;

        public PlayerStateController stateController;
        public PlayerController playerController;
        public PlayerSettingsSO playerSettings;
    }
}