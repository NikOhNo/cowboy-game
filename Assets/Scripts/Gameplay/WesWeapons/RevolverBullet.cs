using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverBullet : ProjectileItem
{
    // Start is called before the first frame update


    void OnCollisionEnter2D(Collision2D other)
    {
        DealDamage(other);
        Destroy(this.gameObject);

    }

    
}
