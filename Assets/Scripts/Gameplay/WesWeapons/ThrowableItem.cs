using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableItem : ProjectileItem
{
    public Vector3 targetCoords;
    public bool isLanded = false;
    public float landLifeTime = 2f;
    public float damageCooldown = .4f;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        targetCoords = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.Normalize(targetCoords - transform.position) * speed;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.isTrigger) return;
        if(other.gameObject.tag != "Player"){
            if(!isLanded)
            {
                timer = 0f;
                lifetime = landLifeTime;
                isLanded = true;
            }
            
        }
            DealDamage(other); //needs to add a damage cooldown Component to the damaged object
        
    }

}
