using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed = 20;

    [SerializeField] private Vector2 moveDirection;
    private Movement movement = new Movement();

    // Start is called before the first frame update
    void Start()
    {
        movement.printHello(rb);
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate(){
         movement.move(rb,speed,moveDirection);
    }

   void ProcessInputs(){
         float moveX = Input.GetAxisRaw("Horizontal");
         float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY);  
        if (Mathf.Abs(moveDirection.x) > Mathf.Abs(moveDirection.y))
        {
            moveDirection.y = 0;
        }
        else
        {
            moveDirection.x = 0;
        }
    }

}

        //if(moveDirection.x != 0){
        //   movement.moveHorizontal(rb,moveDirection.x * speed);
        // }else if(moveDirection.y != 0){
        // movement.moveVertical(rb,moveDirection.y * speed);
        // }
        // else{
        //     movement.moveStop(rb);
        // }
        