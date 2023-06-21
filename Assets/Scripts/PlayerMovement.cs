using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //System Stuff
    private Movement movement = new Movement();
    private Movement.MovementAxis axis;
    [SerializeField] private PlayerMove playerMove;
    
    //Debugging
    [SerializeField] private Vector2 moveDirection;
    [SerializeField] private float debugSpeed;

    private void OnEnable(){
        MoveeProperties.speedChanged += SpeedChange;
    }

    private void OnDisable(){
        MoveeProperties.speedChanged -= SpeedChange;
    }

    private void Start()
    {
        PlayerInitialization();
    }

    private void Update()
    {
        PlayerMove.DebugSpeedChange(playerMove, debugSpeed);
        ProcessInputs();   
    }

    private void FixedUpdate(){
        movement.move(playerMove.UnitMovee, moveDirection);
    }

    private void PlayerInitialization(){
        playerMove.InstantiateMovePoint(playerMove);
        PlayerMove.SetUpUnitMovee(playerMove);
    }

    private void ProcessInputs(){ 
         float moveX = Input.GetAxisRaw("Horizontal");
         float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY); 

        //Anti-input override
        if (Input.GetButtonDown("Horizontal")) axis = Movement.MovementAxis.Horizontal;
        if (Input.GetButtonDown("Vertical")) axis = Movement.MovementAxis.Vertical;

        if (Input.GetButtonUp("Horizontal") && Input.GetButton("Vertical")) axis = Movement.MovementAxis.Vertical;
        if (Input.GetButtonUp("Vertical") && Input.GetButton("Horizontal")) axis = Movement.MovementAxis.Horizontal;
        
        UnOverrideDirection();
    }

    private void UnOverrideDirection(){
        switch (axis)
        {
            case Movement.MovementAxis.Horizontal:
                moveDirection.y = 0;
                break;
            case Movement.MovementAxis.Vertical:
                moveDirection.x = 0;
                break;
        }
    }

    private void SpeedChange(){
        playerMove.UnitMovee.speed = playerMove.Speed;
    }

}


