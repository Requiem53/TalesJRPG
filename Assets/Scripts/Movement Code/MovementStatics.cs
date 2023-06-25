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
    public static void AxisLocker(MovementStatics.MovementAxis axis, float moveDirectionX, float moveDirectionY){
        switch (axis)
        {
            case MovementAxis.Horizontal:
                moveDirectionY = 0;
                break;
            case MovementAxis.Vertical:
                moveDirectionX = 0;
                break;
        }
    }

    public static void AxisLocker(MoveeProperties unit){
        switch (unit.Axis)
        {
            case MovementAxis.Horizontal:
                unit.MoveDirectionY = 0;
                break;
            case MovementAxis.Vertical:
                unit.MoveDirectionX = 0;
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
    public static void MoveTowardsMovePoint(MoveeProperties moveeProps){
        moveeProps.transform.position = Vector3.MoveTowards(moveeProps.transform.position, moveeProps.MovePoint.position, moveeProps.Speed * Time.deltaTime);
    }
}
