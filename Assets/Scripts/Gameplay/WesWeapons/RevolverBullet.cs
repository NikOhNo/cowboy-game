using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverBullet : ProjectileItem
{
    // Start is called before the first frame update


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Damageable")
        {
            if(other.gameObject.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(attackDamage);
                Debug.Log("Hit Enemy");
            }
            
            
            Destroy(this.gameObject);
            

        }
    }

    
}
