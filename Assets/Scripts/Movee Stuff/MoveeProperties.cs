using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public abstract class MoveeProperties : MonoBehaviour
{
    //Serialize if you want to debug
    [SerializeField] private MovementStatics.FaceDirection _faceDirection;
    [SerializeField] private MovementStatics.MovementAxis _axis;
    [SerializeField] private Vector2 _moveDirection;

    [SerializeField] private float _speed = 6;
    [SerializeField] private LayerMask _obstacle;
    
    private Transform _movePoint;

    private GameObject _motherMovePoint;
    private GameObject _parentMovePoint;
    
    public static event Action<MoveeProperties> OnMoveePropsCreation;

    //Gets Mother and Parent Move Point reference from AssignMotherMoveToMovee.cs
    //Mother Move Point serves as the main prefab which all Move Points come from
    //Move Points are used for movement where an object moves towards
    //the move point transform.
    protected void SetUpMotherMovePointReference(MoveeProperties unit){
        OnMoveePropsCreation?.Invoke(unit);
    }

    //Assigns Mother and Parent Move Point to an object.
    public virtual void InstantiateMovePoint(MoveeProperties unit){
        SetUpMotherMovePointReference(unit);
        var objectMovePoint = (GameObject) Instantiate(unit.MotherMovePoint,unit.transform.position,Quaternion.identity, unit.ParentMovePoint.transform);
        objectMovePoint.name = "Object MovePoint";
        unit.MovePoint = objectMovePoint.transform;
    }
    
    private void LateUpdate(){
        MoveeProperties.AxisLocker(this);
    }

    //Locks Movement to 4 directions.
    public static void AxisLocker(MoveeProperties unit){
        switch (unit.Axis)
        {
            case MovementStatics.MovementAxis.Horizontal:
                unit.MoveDirectionY = 0;
                break;
            case MovementStatics.MovementAxis.Vertical:
                unit.MoveDirectionX = 0;
                break;
        }
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

    //Does not work on editor with Unity :(
    //Invokes don't call with setter methods when settings values in Inspector
    public static event Action OnSpeedChange;

    public float Speed{
        get{return _speed;}
        set{
            _speed = value;
            OnSpeedChange?.Invoke();
        }
    }

    public LayerMask Obstacle{
        get{return _obstacle;}
        set{_obstacle = value;}
    }

    public ref MovementStatics.FaceDirection RefFaceDirection{
        get{return ref _faceDirection;}
    }

    public ref MovementStatics.MovementAxis RefAxis{
        get{return ref _axis;}
    }
    public MovementStatics.MovementAxis Axis{
        get{return _axis;}
        set{_axis = value;}
    }

    public ref Vector2 RefMoveDirection{
        get{return ref _moveDirection;}
    }

    public Vector2 MoveDirection{
        get{return _moveDirection;}
        set{_moveDirection = value;}
    }

    public float MoveDirectionX{
        get{return _moveDirection.x;}
        set{_moveDirection.x = value;}
    }

    public float MoveDirectionY{
        get{return _moveDirection.y;}
        set{_moveDirection.y = value;}
    }
}
