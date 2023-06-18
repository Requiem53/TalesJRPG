using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement
{
    public void move(Rigidbody2D rb, float speed, Vector2 moveDirection){
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
        if(rb.velocity.x > 0 || rb.velocity.y > 0){
        Debug.Log("X: " +  rb.velocity.x);
        Debug.Log("Y: " +  rb.velocity.x);
        }
    }

    public void moveHorizontal(Rigidbody2D rb, float speed){
        rb.velocity = new Vector2(speed, 0.0f);
    }

    public void moveVertical(Rigidbody2D rb, float speed){
        rb.velocity = new Vector2(0.0f, speed);
    }

    public void moveStop(Rigidbody2D rb){
        rb.velocity = new Vector2(0.0f, 0.0f);
    }



    public void printHello(Rigidbody2D rb){
        Debug.Log("Miss me with that BS");
    }

    // private float speed;
    // private Rigidbody2D rb;

    // public Movement(Rigidbody2D rb,float speed){
    //     this.rb = rb;
    //     this.speed = speed;
    // }
}

