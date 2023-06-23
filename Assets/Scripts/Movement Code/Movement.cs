using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Movement
{
    public static event Action OnObjectMove;

    //First, always moves object to move point before queueing another movement.
    //Then, stops once object arrives to move point.
    //After that, checks if object really is inside the move point.
    //Then does another check if there is an obstacle to the direction we move.
    //Then applies movement depending on the direction
    public static void Move(Movee movee, Vector2 moveDirection){
        MovementStatics.MoveTowardsMovePoint(movee);

        if(Vector3.Distance(movee.transform.position, movee.movePoint.position) <= 0.05f){

            if(!Physics2D.OverlapCircle(movee.movePoint.position + new Vector3(moveDirection.x, 0f, 0f), .2f, movee.obstacle)){

                if(Mathf.Abs(moveDirection.x) == 1f){
                    movee.movePoint.position += new Vector3(moveDirection.x, 0f, 0f);
                    OnObjectMove?.Invoke();
                }

            }
            if(!Physics2D.OverlapCircle(movee.movePoint.position + new Vector3(0f, moveDirection.y, 0f), .2f, movee.obstacle)){
                if(Mathf.Abs(moveDirection.y) == 1f){
                    movee.movePoint.position += new Vector3(0f, moveDirection.y, 0f);
                    OnObjectMove?.Invoke();
                }
            }
        }
    }

    //Used to update Movee's Axis, Face Direction, and Move Direction
    public static void UpdateDirections(MovementStatics.MovementAxis axis, ref MovementStatics.FaceDirection faceDirection, ref Vector2 moveDirection){
        MovementStatics.AxisLocker(axis, ref moveDirection);
        MovementStatics.FacingDirection(ref faceDirection, ref moveDirection);
    }

    //?? To change
    public void stop(float duration){
        if(duration > 0){
            duration -= Time.deltaTime;
        }
    }


}

