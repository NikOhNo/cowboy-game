using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Weapons.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        /// <summary>
        /// Rotates the projectile between the given degree.
        /// i.e. 30 - can either go 15 degrees up or down from the direction its currently facing
        /// </summary>
        /// <param name="degrees"></param>
        public void RotateBetween(float degrees)
        {
            Quaternion currRotation = transform.rotation;

            float halfDegrees = degrees / 2;
            float randomRotationAmount = UnityEngine.Random.Range(-halfDegrees, halfDegrees);

            transform.Rotate(0f, 0f, randomRotationAmount);
        }

        public void GiveForce(float strength)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * strength);
        }
    }
}