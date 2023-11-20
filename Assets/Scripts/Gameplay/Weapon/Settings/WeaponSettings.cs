using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Weapons.Settings
{
    [CreateAssetMenu(fileName = "newWeaponSettings", menuName = "New Weapon Settings")]
    public class WeaponSettings : ScriptableObject
    {
        //-- SERIALIED FIELDS
        [SerializeField] Sprite sprite;
        [SerializeField] GameObject bulletPrefab;
        [SerializeField][Range(0f, 360f)] float hipfireAccuracyDeg;
        [SerializeField][Range(0f, Mathf.Infinity)] float timeToAim;

        //-- PROPERTIES
        public Sprite WeaponSprite => sprite;
        public GameObject BulletPrefab => bulletPrefab;
        public float HipFireAccuracyDegree => hipfireAccuracyDeg;
        public float TimeToAim => timeToAim;
    }
}