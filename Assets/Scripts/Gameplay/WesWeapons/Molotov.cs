using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molotov : ThrowableItem
{
    public Animator animator;
    public Sprite landedSprite;
    
    bool isExpanded = false;
    protected override void Update()
    {
        base.Update();
        if(Mathf.Abs(targetCoords.x - transform.position.x) <= 0.1f && Mathf.Abs(targetCoords.y - transform.position.y) <= 0.1f)
        {
            isLanded = true;
        }
        if (isLanded && !isExpanded)
        {
            isExpanded = true;
            //animator.SetBool("hasExploded", true);
            LandedBehavior();
            
        }
    }

    public void LandedBehavior(){
        
        rb.velocity = new Vector3(0, 0, 0);
        GetComponent<SpriteRenderer>().sprite = landedSprite;
        //scale transform by 2
        transform.localScale = new Vector3(2, 2, 2);
        //remove capsule collider and change it into a circle collider
        Destroy(GetComponent<CapsuleCollider2D>());
        gameObject.AddComponent<CircleCollider2D>();
        //make isTrigger in circle collider true
        GetComponent<CircleCollider2D>().isTrigger = true;

    }
}
