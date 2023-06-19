using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : Movement
{

   public void moveLeft(Movee movee, int steps){
        for(int i = 0; i < steps; i++){
            move(movee, Vector2.left);
        }
   }
   public void moveRight(Movee movee, int steps){
        for(int i = 0; i < steps; i++){
                move(movee, Vector2.right);
            }
    
   }
   public void moveUp(Movee movee, int steps){
        for(int i = 0; i < steps; i++){
                move(movee, Vector2.up);
            }
   }
   public void moveDown(Movee movee, int steps){
        for(int i = 0; i < steps; i++){
                move(movee, Vector2.down);
            }
   }

}
