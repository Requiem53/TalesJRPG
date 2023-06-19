using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movee 
{
    public Transform movePoint;
    public Transform transform;
    public float speed;
    public LayerMask obstacle;

    public Movee(Transform movePoint, Transform transform, float speed, LayerMask obstacle){
        this.movePoint = movePoint;
        this.transform = transform;
        this.speed = speed;
        this.obstacle = obstacle;
    }
}


public class Movement
{
    public void move(Movee movee, Vector2 moveDirection){

        movee.transform.position = Vector3.MoveTowards(movee.transform.position, movee.movePoint.position, movee.speed * Time.deltaTime);

        if(Vector3.Distance(movee.transform.position, movee.movePoint.position) <= 0.05f){

            if(!Physics2D.OverlapCircle(movee.movePoint.position + new Vector3(moveDirection.x, 0f, 0f), .2f, movee.obstacle)){

                if(Mathf.Abs(moveDirection.x) == 1f){
                    movee.movePoint.position += new Vector3(moveDirection.x, 0f, 0f);
                }

            }

            if(!Physics2D.OverlapCircle(movee.movePoint.position + new Vector3(0f, moveDirection.y, 0f), .2f, movee.obstacle)){
                if(Mathf.Abs(moveDirection.y) == 1f){
                    movee.movePoint.position += new Vector3(0f, moveDirection.y, 0f);
                }
            }
        }
    }

    public void stop(float duration){
        if(duration > 0){
            duration -= Time.deltaTime;
        }
    }

    public enum MovementAxis
    {
        Vertical,
        Horizontal
    }
}

//USELESS FOR NOW
// public abstract class MoveeSetter{
//     public abstract void InstantiateMovePoint();
//     public abstract void SetUpUnitMovee();

// }

