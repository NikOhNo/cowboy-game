using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter : MonoBehaviour
{
    public enum State
    {
        Idle,
        Walking,
        DodgeRolling
    };
    public State playerState = State.Idle;
    public float speed = 5.0f;
    Rigidbody2D rb;
    private float horizontalInput;
    private float verticalInput;
    private bool againstWall = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        //TODO: Apply speed slower to diagonal movement
        
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        HandleState();
        if(playerState == State.Walking){
            Vector2 movement = new Vector2(horizontalInput, verticalInput);
            float currentSpeed = speed;
            if(againstWall){
                //TODO: When moving diagonally along a wall, just go fully horizontal or vertical
            }
            else if(horizontalInput != 0 && verticalInput != 0){
                currentSpeed *= 0.7f;
            }
            movement.Normalize();
            rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        }
        
    
    }


    void HandleState(){
        if(playerState == State.Idle && (horizontalInput != 0 || verticalInput != 0)){
            playerState = State.Walking;
        }
        else if(playerState == State.Walking && (horizontalInput == 0 && verticalInput == 0)){
            playerState = State.Idle;
        }
        /*else if(player.State == State.Walking && Input.GetKeyDown(KeyCode.Space)){
            playerState = State.DodgeRolling;
        }
        Need more dodge rolling info to complete this part
        */
        
    }

    void OnCollisionEnter2D(Collision2D other){
        againstWall = true;
    }

    void OnCollisionExit2D(Collision2D other){
        againstWall = false;
    }
}
