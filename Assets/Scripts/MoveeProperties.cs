using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public abstract class MoveeProperties : MonoBehaviour
{

    private GameObject motherMovePoint;
    private GameObject parentMovePoint;

    private Transform movePoint;
    [SerializeField] private float speed = 6;
    [SerializeField] private LayerMask obstacle;

    [SerializeField] private Movee unitMovee;

    //Debugging
    private float debugSpeed;

    public static event Action<MoveeProperties> OnCreation;

    protected void SetUpMotherMovePointReference(MoveeProperties unit){
        OnCreation?.Invoke(unit);
    }

    public static void SetUpUnitMovee(MoveeProperties unit){
        unit.UnitMovee = new Movee(unit.MovePoint,unit.transform,unit.Speed,unit.Obstacle);
    }

    public void InstantiateMovePoint(MoveeProperties unit){
        SetUpMotherMovePointReference(unit);
        var mcMovePoint = (GameObject) Instantiate(unit.MotherMovePoint,transform.position,Quaternion.identity, unit.ParentMovePoint.transform);
        mcMovePoint.name = "Player MovePoint";
        unit.MovePoint = mcMovePoint.transform;
    }

    //Debug Tools

    public static void DebugSpeedChange(MoveeProperties unit, float debugSpeed){
        if(unit.UnitMovee.speed != debugSpeed){
            unit.UnitMovee.speed = debugSpeed;
        }
        
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

    //Does not work on editor with Unity :(
    public static event Action speedChanged;

    public float Speed{
        get{return speed;}
        set{
            speed = value;
            speedChanged?.Invoke();
        }
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
