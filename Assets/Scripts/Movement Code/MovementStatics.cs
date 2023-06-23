using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStatics
{
    //Named Statics because it contains all abstraction stuff for Movement.cs
    public enum MovementAxis
    {
        Vertical,
        Horizontal
    }

    public enum FaceDirection
    {
        North,
        South,
        East,
        West
    }

    //Handles Movement so it can only ever be four directions
    public static void AxisLocker(MovementAxis axis, ref Vector2 moveDirection){
        switch (axis)
        {
            case MovementAxis.Horizontal:
                moveDirection.y = 0;
                break;
            case MovementAxis.Vertical:
                moveDirection.x = 0;
                break;
        }
    }

    //Handles what direction its facing. Might merge with axis but separated for clarity
    //and potential other use case.
    public static void FacingDirection(ref FaceDirection direction, ref Vector2 moveDirection){
        if(moveDirection.x == 0 && moveDirection.y == 1){
            direction = FaceDirection.North;
        }else if(moveDirection.x == 0 && moveDirection.y == -1){
            direction = FaceDirection.South;
        }else if(moveDirection.x == 1 && moveDirection.y == 0){
            direction = FaceDirection.East;
        }else if(moveDirection.x == -1 && moveDirection.y == 0){
            direction = FaceDirection.West;
        }else{
            direction = FaceDirection.South;
        }
    }
    
    //Makes object move towards Move Point
    public static void MoveTowardsMovePoint(Movee movee){
        movee.transform.position = Vector3.MoveTowards(movee.transform.position, movee.movePoint.position, movee.speed * Time.deltaTime);
    }
}
