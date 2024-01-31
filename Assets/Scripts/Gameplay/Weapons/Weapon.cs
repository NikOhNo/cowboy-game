using Assets.Scripts.Gameplay.Weapons.Helpers;
using Assets.Scripts.Gameplay.Weapons.Settings;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField]
        private WeaponSettingsSO weaponSettings;

        [SerializeField]
        protected Transform projectileSpawnPoint;

        [SerializeField]
        protected WeaponAimer aimer;

        public WeaponSettingsSO Settings => weaponSettings;

        public abstract void Fire();
    }   
}