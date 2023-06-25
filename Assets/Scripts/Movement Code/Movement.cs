using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Movement
{
    //public static event Action OnObjectMove;

    //First, always moves object to move point before queueing another movement.
    //Then, stops once object arrives to move point.
    //After that, checks if object really is inside the move point.
    //Then does another check if there is an obstacle to the direction we move.
    //Then applies movement depending on the direction.
    //Then changes the indicator of the direction faced.
    public static void Move(MoveeProperties moveeProps, Vector2 moveDirection){
        MovementStatics.MoveTowardsMovePoint(moveeProps);

        if(Vector3.Distance(moveeProps.transform.position, moveeProps.MovePoint.position) <= 0.05f){

            if(!Physics2D.OverlapCircle((moveeProps.MovePoint.position + new Vector3(moveDirection.x, 0f, 0f)), .2f, moveeProps.Obstacle)){

                if(Mathf.Abs(moveDirection.x) == 1f){
                    moveeProps.MovePoint.position += new Vector3(moveDirection.x, 0f, 0f);
                    UpdateDirections(ref moveeProps.RefFaceDirection, ref moveeProps.RefMoveDirection);
                }

            }
            if(!Physics2D.OverlapCircle(moveeProps.MovePoint.position + new Vector3(0f, moveDirection.y, 0f), .2f, moveeProps.Obstacle)){
                if(Mathf.Abs(moveDirection.y) == 1f){
                    moveeProps.MovePoint.position += new Vector3(0f, moveDirection.y, 0f);
                    UpdateDirections(ref moveeProps.RefFaceDirection, ref moveeProps.RefMoveDirection);
                }
            }
        }
    }

    //Used to update Movee's Axis, Face Direction, and Move Direction
    public static void UpdateDirections(ref MovementStatics.FaceDirection faceDirection, ref Vector2 moveDirection)
    {
        MovementStatics.FacingDirection(ref faceDirection, ref moveDirection);
    }

    //?? To change
    public void stop(float duration){
        if(duration > 0){
            duration -= Time.deltaTime;
        }
    }


}

