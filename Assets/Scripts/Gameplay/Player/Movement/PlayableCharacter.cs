using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter : MonoBehaviour
{
    public enum MoveState
    {
        Idle,
        Walking,
        DodgeRolling
    };

    public enum AttackState
    {
        Idle,
        Attacking
    };//might add more for weapons and whatnot...
    public MoveState playerState = MoveState.Idle;
    public AttackState playerAttackState = AttackState.Idle;
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
        MovementLogic();
        AttackLogic();
        
    
    }


    void MovementLogic(){
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        HandleMoveState();
        if(playerState == MoveState.Walking){
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

    void HandleMoveState(){
        if(playerState == MoveState.Idle && (horizontalInput != 0 || verticalInput != 0)){
            playerState = MoveState.Walking;
        }
        else if(playerState == MoveState.Walking && (horizontalInput == 0 && verticalInput == 0)){
            playerState = MoveState.Idle;
        }
        /*else if(player.State == State.Walking && Input.GetKeyDown(KeyCode.Space)){
            playerState = State.DodgeRolling;
        }
        Need more dodge rolling info to complete this part
        */
        
    }


    void AttackLogic(){
        if(playerAttackState == AttackState.Idle && Input.GetMouseButton(0)){
            playerAttackState = AttackState.Attacking;
        }
        else if(playerAttackState == AttackState.Attacking && !Input.GetMouseButton(0)){
            playerAttackState = AttackState.Idle;
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        againstWall = true;
    }

    void OnCollisionExit2D(Collision2D other){
        againstWall = false;
    }
}
