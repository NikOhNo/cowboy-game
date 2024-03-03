using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatGrenade : ThrowableItem
{
    public Animator animator;
    public float catSpeed = 15f;
    private float angle = 0f;

    protected override void Update()
    {
        base.Update();
        if(Mathf.Abs(targetCoords.x - transform.position.x) <= 0.1f && Mathf.Abs(targetCoords.y - transform.position.y) <= 0.1f)
        {
            isLanded = true;
        }
        if (isLanded)
        {
            //animator.SetBool("hasExploded", true);
            LandedBehavior();
            
        }
    }


    void LandedBehavior()
    {
        float xVelocity = -Mathf.Sin(angle) * catSpeed;
        float yVelocity = Mathf.Cos(angle) * catSpeed;

        rb.velocity = new Vector3(xVelocity, yVelocity, 0f);
        angle += catSpeed * Time.deltaTime;

        // Ensures the angle stays within the 0 to 2*pi range
        if (angle > 2 * Mathf.PI)
        {
            angle -= 2 * Mathf.PI;
        }
    }
    
}
