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
    //Then, it checks what direction its supposed to move next.
    //Then, it adjusts what direction the player should be facing.
    //Then, does another check if there is an obstacle to the direction we move.
    //Then applies movement depending on the direction.

    public static void Move(MoveeProperties moveeProps, Vector2 moveDirection, SpriteRenderer renderer, bool HasMoved)
    {
        MovementStatics.MoveTowardsMovePoint(moveeProps);
        if(Vector3.Distance(moveeProps.transform.position, moveeProps.MovePoint.position) <= 0.05f)
        {
            if(HasMoved)
            {
                Debug.Log("And even though it's such a goddamn lie");
                //Technically called on object stop but whatevs.
                OnObjectMove?.Invoke();
            }
            if(Mathf.Abs(moveDirection.x) == 1f)
            {
                MovementStatics.FacingDirection(ref moveeProps.RefFaceDirection, ref moveeProps.RefMoveDirection, moveeProps.Animator);
                if(!Physics2D.OverlapBox(moveeProps.MovePoint.position + new Vector3(moveDirection.x, 0f, 0f), renderer.bounds.size, 0, moveeProps.Obstacle))
                {
                    OnObjectMove?.Invoke();
                    moveeProps.MovePoint.position += new Vector3(moveDirection.x, 0f, 0f);
                }
            }
            if(Mathf.Abs(moveDirection.y) == 1f)
            {
                MovementStatics.FacingDirection(ref moveeProps.RefFaceDirection, ref moveeProps.RefMoveDirection, moveeProps.Animator);
                if(!Physics2D.OverlapBox(moveeProps.MovePoint.position + new Vector3(0f, moveDirection.y, 0f), renderer.bounds.size, 0, moveeProps.Obstacle)){
                    OnObjectMove?.Invoke();
                    moveeProps.MovePoint.position += new Vector3(0f, moveDirection.y, 0f);  
                }
            }
        }
    }


    //?? To change
    public void Stop(float duration){
        if(duration > 0){
            duration -= Time.deltaTime;
        }
    }


}

