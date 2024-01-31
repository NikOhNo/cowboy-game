using Assets.Scripts.Gameplay.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Events
{
    [CreateAssetMenu(menuName = "Events/New Weapon Event Channel")]
    public class WeaponEventChannelSO : ScriptableObject
    {
        public Weapon CurrentWeapon => heldWeapons[currentWeaponIndex];
        public List<Weapon> heldWeapons;
        private int currentWeaponIndex = 0;

        public UnityEvent<Weapon> OnGainWeapon;
        public UnityEvent<Weapon> OnWeaponChanged;
        public UnityEvent<bool> OnEnableWeapon;
        public UnityEvent<float> OnFireWeapon;
    }
}