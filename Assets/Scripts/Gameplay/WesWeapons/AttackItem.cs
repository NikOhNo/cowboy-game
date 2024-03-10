using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackItem : MonoBehaviour
{
    public int attackPower = 10;
    public GameObject projectilePrefab;
    public bool canUse = true;
    public float reloadTime = 1.5f;
    protected float reloadTimer = 0;
    

    public Transform playerTransform; // Assign the player's transform in the Unity Editor
    

    protected virtual void Update()
    {
        if (canUse && Input.GetButtonDown("Fire1")) // Assuming "Fire1" is the left mouse button
        {
            ShootProjectile();
            //get parent game object
            transform.parent.GetComponent<WeaponScroll>().UpdateAmmoCount(-1);
        }
    }

    public virtual void ShootProjectile()
    {
        Debug.Log("Shooting projectile");
    }

}
