using Assets.Scripts.Events;
using System.Collections;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Weapons.Helpers
{
    [RequireComponent(typeof(Weapon))]
    public class WeaponAimer : MonoBehaviour
    {
        public float CurrentAccuracy { get; private set; }

        [SerializeField]
        private WeaponEventChannelSO weaponChannel;

        private Weapon weapon;

        //-- Helper Variables
        private float elapsedAimTime = 0f;
        Coroutine aimCoroutine;

        private void Awake()
        {
            weapon = GetComponent<Weapon>();
        }

        public void StartAiming()
        {
            ResetAim();
            aimCoroutine = StartCoroutine(PerformAiming());
        }

        /// <summary>
        /// Updates the time spent aiming & accuracy until it reaches the full time to aim for the weapon
        /// </summary>
        /// <returns></returns>
        IEnumerator PerformAiming()
        {
            elapsedAimTime = 0f;
            while (elapsedAimTime < weapon.Settings.TimeToAim)
            {
                elapsedAimTime += Time.deltaTime;
                UpdateCurrentAccuracy();
                yield return null;
            }
        }

        public void StopAiming()
        {
            StopCoroutine(aimCoroutine);
            ResetAim();
        }

        /// <summary>
        /// Sets the aim degree to the hipfire accuracy
        /// </summary>
        private void ResetAim()
        {
            elapsedAimTime = 0f;
            UpdateCurrentAccuracy();
        }

        /// <summary>
        /// Determines the current aim degree based on the amount of time spent aiming
        /// </summary>
        private void UpdateCurrentAccuracy()
        {
            // TODO: Debug if this is working
            CurrentAccuracy = Mathf.Lerp(weapon.Settings.HipFireAccuracyDegree, 0f, elapsedAimTime / weapon.Settings.TimeToAim);
        }
    }
}