using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private NPCMovement nPCMovement = new NPCMovement();
    //Properties
    [SerializeField] private GameObject motherMovePoint;
    [SerializeField] private GameObject parentMovePoint;
    
    [SerializeField] private Transform movePoint;
    [SerializeField] private float speed = 6;
    [SerializeField] private LayerMask groundObstacle;

    private Movee nPCMovee;

    [SerializeField] private Rigidbody2D rb;
    

    void Awake()
    {
        InstantiateMovePoint();
        SetUpPlayerMovee();
    }


    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Z)){
        nPCMovement.moveLeft(nPCMovee, 1);
        }         
    }

    void InstantiateMovePoint(){
        var mcMovePoint = (GameObject) Instantiate(motherMovePoint,transform.position,Quaternion.identity, parentMovePoint.transform);
        mcMovePoint.name = "NPC MovePoint";
        movePoint = mcMovePoint.transform;
    }
    
    void SetUpPlayerMovee(){
        nPCMovee = new Movee(movePoint,transform,speed,groundObstacle);
    }
}
