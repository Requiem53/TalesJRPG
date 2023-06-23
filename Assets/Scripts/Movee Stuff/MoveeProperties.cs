using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public abstract class MoveeProperties : MonoBehaviour
{
    //Serialize if you want to debug
    [SerializeField] private MovementStatics.FaceDirection faceDirection;
    private MovementStatics.MovementAxis axis;
    [SerializeField] private float _speed = 6;
    [SerializeField] private LayerMask _obstacle;
    private Vector2 moveDirection;

    private Movee unitMovee;

    private Transform _movePoint;

    private GameObject _motherMovePoint;
    private GameObject _parentMovePoint;
    
    public static event Action<MoveeProperties> OnMoveePropsCreation;

    private void OnEnable(){
        Movement.OnObjectMove += UpdateDirections;
    }

    private void OnDisable(){
        Movement.OnObjectMove -= UpdateDirections;
    }


    //Gets Mother and Parent Move Point reference from AssignMotherMoveToMovee.cs
    //Mother Move Point serves as the main prefab which all Move Points come from
    //Move Points are used for movement where an object moves towards
    //the move point transform.
    protected void SetUpMotherMovePointReference(MoveeProperties unit){
        OnMoveePropsCreation?.Invoke(unit);
    }

    //Assigns Movee Property values to a Movee Variable.
    //Movee Properties below the class
    public void SetUpUnitMovee(MoveeProperties unit){
        Debug.Log("I wonder what'm gnna screw up this time");
        unit.UnitMovee = new Movee(unit.MovePoint,unit.transform,unit._speed,unit._obstacle);
    }

    //Assigns Mother and Parent Move Point to an object.
    public virtual void InstantiateMovePoint(MoveeProperties unit){
        SetUpMotherMovePointReference(unit);
        var objectMovePoint = (GameObject) Instantiate(unit.MotherMovePoint,unit.transform.position,Quaternion.identity, unit.ParentMovePoint.transform);
        objectMovePoint.name = "Object MovePoint";
        unit.MovePoint = objectMovePoint.transform;
    }

    //Used to update the Axis, Face Direction, and MoveDirection of a Movee
    private void UpdateDirections(){
        Movement.UpdateDirections(Axis, ref FaceDirection, ref MoveDirection);
    }

    public GameObject MotherMovePoint{
        get{return _motherMovePoint;}
        set{_motherMovePoint = value;}
    }

    public GameObject ParentMovePoint{
        get{return _parentMovePoint;}
        set{_parentMovePoint = value;}
    }

    public Transform MovePoint{
        get{return _movePoint;}
        set{_movePoint = value;}
    }

    public Movee UnitMovee{
        get{return unitMovee;}
        set{unitMovee = value;}
    }

    //Does not work on editor with Unity :(
    //Invokes don't call with setter methods when settings values in Inspector
    public static event Action OnSpeedChange;

    public float Speed{
        get{return _speed;}
        set{
            UnitMovee.speed = value;
            OnSpeedChange?.Invoke();
        }
    }

    public LayerMask Obstacle{
        get{return _obstacle;}
        set{UnitMovee.obstacle = value;
                                }
    }

    public ref MovementStatics.FaceDirection FaceDirection{
        get{return ref faceDirection;}
    }

    public static event Action OnAxisChange;
    public MovementStatics.MovementAxis Axis{
        get{return axis;}
        set{
            axis = value;
            OnAxisChange?.Invoke();}
    } 

    public ref Vector2 MoveDirection{
        get{return ref moveDirection;}
    }
}

public class Movee 
{
    //A Movee contains the Point at which the object moves toward, it's transform,
    //speed, and what it can go through.
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
