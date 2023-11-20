using Assets.Scripts.Gameplay.Weapons.Settings;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField]
        WeaponSettings weaponSettings;

        public WeaponSettings Settings => weaponSettings;

        public abstract void Fire(float accuracy);
    }   
}