using Assets.Scripts.Gameplay.Weapons.Settings;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField]
        private WeaponSettings weaponSettings;

        [SerializeField]
        protected Transform projectileSpawnPoint;

        public WeaponSettings Settings => weaponSettings;

        public abstract void Fire(float accuracy);
    }   
}