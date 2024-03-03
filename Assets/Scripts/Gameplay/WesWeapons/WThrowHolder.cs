using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WThrowHolder : AttackItem
{
    
    public int throwableCount = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void Update()
    {
        base.Update();
        if (!canUse)
        {
            reloadTimer += Time.deltaTime;
            if (reloadTimer >= reloadTime)
            {
                canUse = true;
                reloadTimer = 0;
            }
        }
        
    }

    public override void ShootProjectile()
    {
        GameObject projectileInstance = Instantiate(projectilePrefab, transform.position, transform.parent.rotation);
        projectileInstance.GetComponent<ThrowableItem>().SetAttackDamage(attackPower);
        
        canUse = false;
        throwableCount--;
    }


}
