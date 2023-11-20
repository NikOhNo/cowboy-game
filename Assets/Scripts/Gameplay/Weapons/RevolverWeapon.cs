using Assets.Scripts.Gameplay.Weapons;
using Assets.Scripts.Gameplay.Weapons.Projectiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverWeapon : Weapon
{
    public override void Fire(float accuracy)
    {
        GameObject projectileObj = Instantiate(Settings.ProjectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        Projectile projectile = projectileObj.GetComponent<Projectile>();

        projectile.RotateBetween(accuracy);
        projectile.GiveForce(Settings.ProjectileSpeed);
    }
}
