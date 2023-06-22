using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerMovementInput : MonoBehaviour
{
    //Contains Input for Movement and Player Initialization

    //Debugging
    //Serialize if you want to debug
    [SerializeField] private MovementStatics.FaceDirection faceDirection;
    private MovementStatics.MovementAxis axis;
    private Vector2 moveDirection;

    //System Stuff
    private PlayerMoveeProperties playerMoveeProperties;
    private Movement movement = new Movement();  

    public static event Action<PlayerMovementInput> OnPlayerMovementInputCreation;

    private void OnEnable(){
        //Detects Speed Change but does not work with inspector
        MoveeProperties.speedChanged += SpeedChange;
    }

    private void OnDisable(){
        MoveeProperties.speedChanged -= SpeedChange;
    }

    private void Start()
    {
        PlayerInitializing();
    }

    private void Update()
    {
        SpeedChange();
        ProcessInputs();  
    }

    private void FixedUpdate(){
        PlayerMoving();
    }

    //First, references the PlayerMove which contains all Movee Properties data.
    //Then, instantiates the move points and their references.
    //Then, sets up Movee based on Movee Properties.
    private void PlayerInitializing(){
        OnPlayerMovementInputCreation?.Invoke(this);
        playerMoveeProperties.InstantiateMovePoint(playerMoveeProperties);
        PlayerMoveeProperties.SetUpUnitMovee(playerMoveeProperties);
    }
    
    //Guess what this is for..
    private void ProcessInputs(){ 
         float moveX = Input.GetAxisRaw("Horizontal");
         float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY); 

        InputOverride();

        MovementStatics.UnOverrideDirection(axis, ref moveDirection);
        MovementStatics.FacingDirection(ref faceDirection, ref moveDirection);
    }

    //Makes it so if the Player inputs another movement, it changes to that.
    //Overriding the previous direction with the new direction.
    private void InputOverride(){
        if (Input.GetButtonDown("Horizontal")) axis = MovementStatics.MovementAxis.Horizontal;
        if (Input.GetButtonDown("Vertical")) axis = MovementStatics.MovementAxis.Vertical;

        if (Input.GetButtonUp("Horizontal") && Input.GetButton("Vertical")) axis = MovementStatics.MovementAxis.Vertical;
        if (Input.GetButtonUp("Vertical") && Input.GetButton("Horizontal")) axis = MovementStatics.MovementAxis.Horizontal;
        
    }

    //Hands over Player Movee and Move Direction to manipulate movement in Movement.cs
    private void PlayerMoving(){
        movement.move(playerMoveeProperties.UnitMovee, moveDirection);
    }

    //Used for changing speed. Currently also in Update.
    private void SpeedChange(){
        playerMoveeProperties.UnitMovee.speed = playerMoveeProperties.Speed;
    }

    public PlayerMoveeProperties PlayerMoveeProperties{
        get{return playerMoveeProperties;}
        set{playerMoveeProperties = value;}
    }

}


