using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileItem : MonoBehaviour
{
    public float speed = 20f;
    public int attackDamage = 20;
    public Rigidbody2D rb;
    public float lifetime = 5f;
    protected float timer = 0f;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    public void SetAttackDamage(int newAttackDamage)
    {
        attackDamage = newAttackDamage;
        
    }

    public void DealDamage(Collision2D other){
        if (other.gameObject.tag == "Damageable")
        {
            if(other.gameObject.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(attackDamage);
                Debug.Log("Hit Enemy");
            }
        }
    }
    public void DealDamage(Collider2D other){
        if (other.gameObject.tag == "Damageable")
        {
            if(other.gameObject.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(attackDamage);
                Debug.Log("Hit Enemy");
            }
        }
    }


}
