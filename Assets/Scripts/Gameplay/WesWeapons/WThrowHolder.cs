using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WThrowHolder : AttackItem
{
    
    public int throwableCount = 3;
    public GameObject MouseTarget;
    private GameObject mouseTargetInstance;
    public GameObject rechargeText;
    // Start is called before the first frame update
    void Start()
    {
        mouseTargetInstance = Instantiate(MouseTarget, Vector3.zero, Quaternion.identity, this.transform);
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
                rechargeText.SetActive(false);
            }
            mouseTargetInstance.SetActive(false);
        }
        else
        {
            mouseTargetInstance.SetActive(true);
        }
        
    }

    public override void ShootProjectile()
    {
        if(throwableCount <= 0)
        {
            return;
        }
        GameObject projectileInstance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectileInstance.GetComponent<ThrowableItem>().SetAttackDamage(attackPower);
        
        canUse = false;
        throwableCount--;
        if(throwableCount >= 0)
        {
            rechargeText.SetActive(true);
        }

    }


}
