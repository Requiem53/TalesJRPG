using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveeProperties : MonoBehaviour
{
    [SerializeField] private GameObject motherMovePoint;
    [SerializeField] private GameObject parentMovePoint;

    [SerializeField] private Transform movePoint;
    [SerializeField] private float speed = 8;
    [SerializeField] private LayerMask obstacle;

    //Debugging
    [SerializeField] private Movee unitMovee;

    public void SetUpUnitMovee(MoveeProperties unit){
        unit.UnitMovee = new Movee(unit.MovePoint,unit.transform,unit.Speed,unit.Obstacle);
    }

    public void InstantiateMovePoint(MoveeProperties unit){
        var mcMovePoint = (GameObject) Instantiate(unit.MotherMovePoint,transform.position,Quaternion.identity, unit.ParentMovePoint.transform);
        mcMovePoint.name = "Player MovePoint";
        unit.MovePoint = mcMovePoint.transform;
    }
    
    public GameObject MotherMovePoint{
        get{return motherMovePoint;}
        set{motherMovePoint = value;}
    }

    public GameObject ParentMovePoint{
        get{return parentMovePoint;}
        set{parentMovePoint = value;}
    }

    public Transform MovePoint{
        get{return movePoint;}
        set{movePoint = value;}
    }

    public float Speed{
        get{return speed;}
        set{speed = value;}
    }

    public LayerMask Obstacle{
        get{return obstacle;}
        set{obstacle = value;}
    }

    public Movee UnitMovee{
        get{return unitMovee;}
        set{unitMovee = value;}
    }

}
