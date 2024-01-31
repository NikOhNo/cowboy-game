using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Weapons.Settings
{
    [CreateAssetMenu(fileName = "newWeaponSettings", menuName = "Game Settings/New Weapon Settings")]
    public class WeaponSettingsSO : ScriptableObject
    {
        //-- SERIALIED FIELDS
        [SerializeField] Sprite sprite;
        [SerializeField] GameObject projectilePrefab;
        [SerializeField] float projectileSpeed = 25.0f;
        [SerializeField] float hipfireAccuracyDegree = 45.0f;
        [SerializeField] float timeToAim = 1.5f;

        //-- PROPERTIES
        public Sprite WeaponSprite => sprite;
        public GameObject ProjectilePrefab => projectilePrefab;
        public float ProjectileSpeed => projectileSpeed;
        public float HipFireAccuracyDegree => hipfireAccuracyDegree;
        public float TimeToAim => timeToAim;
    }
}