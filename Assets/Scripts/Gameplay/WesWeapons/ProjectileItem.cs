using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileItem : MonoBehaviour
{
    public float speed = 20f;
    public int attackDamage = 20;
    Rigidbody2D rb;
    public float lifetime = 5f;
    private float timer = 0f;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
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


}
