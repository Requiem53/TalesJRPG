using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Properties
    [SerializeField] private GameObject motherMovePoint;
    [SerializeField] private GameObject parentMovePoint;

    [SerializeField] private Transform movePoint;
    [SerializeField] private float speed = 6;
    [SerializeField] private LayerMask groundObstacle;
    private Movement movement = new Movement();
    private Movee playerMovee;

    //System Stuff
    private Movement.MovementAxis axis;
    
    //Debugging
    [SerializeField] private Vector2 moveDirection;
    

    void Awake()
    {
       InstantiateMovePoint();
       SetUpPlayerMovee();
    }

    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate(){
        UnOverrideDirection();
        movement.move(playerMovee, moveDirection);
    }

    void InstantiateMovePoint(){
        var mcMovePoint = (GameObject) Instantiate(motherMovePoint,transform.position,Quaternion.identity, parentMovePoint.transform);
        mcMovePoint.name = "Player MovePoint";
        movePoint = mcMovePoint.transform;
    }
    
    void SetUpPlayerMovee(){
        playerMovee = new Movee(movePoint,transform,speed,groundObstacle);
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


