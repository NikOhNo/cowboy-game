using Assets.Scripts.Gameplay.Weapons;
using Assets.Scripts.Gameplay.Weapons.Projectiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverWeapon : Weapon
{
    public override void Fire()
    {
        GameObject projectileObj = Instantiate(Settings.ProjectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        Projectile projectile = projectileObj.GetComponent<Projectile>();

        projectile.RotateBetween(aimer.CurrentAccuracy);
        projectile.GiveForce(Settings.ProjectileSpeed);
    }
}
