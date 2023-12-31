using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerMovementInput : MonoBehaviour
{
    //Contains Input for Movement and Player Initialization
    //This is so fundamentally flawed

    //System Stuff
    private PlayerMoveeProperties playerMoveeProperties;

    //Move to Movee Properties later
    
    private void Start()
    {
        PlayerInitializing();
    }

    private void Update()
    {
        ProcessInputs(); 
    }

    private void FixedUpdate(){
        PlayerMoving();
    }

    // private void OnEnable(){
    //     Movement.OnObjectMove += TestArrive;
    // }

    // private void OnDisable(){
    //     Movement.OnObjectMove -= TestArrive;
    // }

    // private void TestArrive(){
    //     Debug.Log(this.gameObject.name + " has arrived to their move point");
    // }

    //First, references the PlayerMove which contains all Movee Properties data.
    //Then, instantiates the move points and their references.
    //Then, sets up Movee based on Movee Properties.
    private void PlayerInitializing(){
        playerMoveeProperties = this.GetComponent<PlayerMoveeProperties>();
        playerMoveeProperties.InstantiateMovePoint(this.playerMoveeProperties);
    }
    
    //Guess what this is for..
    private void ProcessInputs(){ 
         float moveX = Input.GetAxisRaw("Horizontal");
         float moveY = Input.GetAxisRaw("Vertical");

        playerMoveeProperties.MoveDirection = new Vector2(moveX, moveY); 

        InputOverride();
    }

    //Makes it so if the Player inputs another movement, it changes to that.
    //Overriding the previous direction with the new direction.
    private void InputOverride(){
        if (Input.GetButtonDown("Horizontal")) playerMoveeProperties.RefAxis = MovementStatics.MovementAxis.Horizontal;
        if (Input.GetButtonDown("Vertical")) playerMoveeProperties.RefAxis = MovementStatics.MovementAxis.Vertical;

        if (Input.GetButtonUp("Horizontal") && Input.GetButton("Vertical")) playerMoveeProperties.RefAxis = MovementStatics.MovementAxis.Vertical;
        if (Input.GetButtonUp("Vertical") && Input.GetButton("Horizontal")) playerMoveeProperties.RefAxis = MovementStatics.MovementAxis.Horizontal;
    }

    //Hands over Player Movee and Move Direction to manipulate movement in Movement.cs
    private void PlayerMoving(){
        Movement.Move(playerMoveeProperties, playerMoveeProperties.MoveDirection, playerMoveeProperties.SpriteRenderer, playerMoveeProperties.HasMoved);
    }

    public PlayerMoveeProperties PlayerMoveeProperties{
        get{return playerMoveeProperties;}
        set{playerMoveeProperties = value;}
    }
}


