using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Player
{
    [CreateAssetMenu(fileName = "newPlayerSettings", menuName = "Game Settings/New Player Settings")]
    public class PlayerSettingsSO : ScriptableObject
    {
        //-- SERIALIED FIELDS
        [SerializeField] float moveSpeed = 7.5f;
        [SerializeField] float aimMoveModifier = .33f;
        [SerializeField] float dodgeSpeed = 7.5f;
        [SerializeField] float dodgeTime = 0.7f;

        //-- PROPERTIES
        // Movement
        public float MoveSpeed => moveSpeed;
        public float AimMoveModifier => aimMoveModifier;
        // Dodgement
        public float DodgeSpeed => dodgeSpeed;
        public float DodgeTime => dodgeTime;
    }
}