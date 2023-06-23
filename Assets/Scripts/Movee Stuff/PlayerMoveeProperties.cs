using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveeProperties : CharacterMoveeProperties
{
    public override void InstantiateMovePoint(MoveeProperties unit)
    {
        SetUpMotherMovePointReference(unit);
        var objectMovePoint = (GameObject) Instantiate(unit.MotherMovePoint,unit.transform.position,Quaternion.identity, unit.ParentMovePoint.transform);
        objectMovePoint.name = "Player MovePoint";
        unit.MovePoint = objectMovePoint.transform;
    }

}
