using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Weapons.Projectiles
{
    public class BulletProjectile : Projectile
    {
        private void Start()
        {
            Destroy(this.gameObject, 5f);
        }
    }
}