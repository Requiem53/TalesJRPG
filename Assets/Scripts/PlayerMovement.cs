using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //System Stuff
    private Movement movement = new Movement();
    private Movement.MovementAxis axis;
    [SerializeField] private Player player;
    
    //Debugging
    [SerializeField] private Vector2 moveDirection;
    

    void Start()
    {
        PlayerInitialization();
    }

    void Update()
    {
        ProcessInputs();
        
    }

    void FixedUpdate(){
        movement.move(player.UnitMovee, moveDirection);
    }

    void PlayerInitialization(){
        player.InstantiateMovePoint(player);
        player.SetUpUnitMovee(player);
    }

    void ProcessInputs(){ 
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

    public void UnOverrideDirection(){
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

}


