using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WRevolver : AttackItem
{
    public int bulletCap = 6;
    public int bulletsLoaded = 6;
    public int bulletCount = 30;
    
    void Start()
    {
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetButtonDown("Fire2"))
        {
            Reload();
        }
    }
    public override void ShootProjectile()
    {
        GameObject projectileInstance = Instantiate(projectilePrefab, transform.GetChild(0).position, transform.parent.rotation);
        projectileInstance.GetComponent<RevolverBullet>().SetAttackDamage(attackPower);

        bulletsLoaded--;
        bulletCount--;
        if (bulletsLoaded <= 0)
        {
            canUse = false;
            Debug.Log("Out of bullets, Right click to reload");
        }
    }

    public void Reload()
    {
        if (bulletsLoaded < bulletCap && bulletCount > 0)
        {
            bulletsLoaded = bulletCap;
            canUse = true;
        }
    }
}
