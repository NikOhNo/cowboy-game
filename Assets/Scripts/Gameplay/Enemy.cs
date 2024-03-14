using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int damage = 10;
    //maybe a variable to keep track of their health.
    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }
    protected virtual void Update()
    {
        
    }
    protected virtual void Attack()
    {
        
    }

    public virtual void TakeDamage(int dmg)
    {
       
        health -= dmg;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
