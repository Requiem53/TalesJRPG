using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AssignMotherMoveToMovee : MonoBehaviour
{
   [SerializeField] private GameObject motherMovePoint;
   [SerializeField] private GameObject parentMovePoint;

    private void OnEnable(){
        MoveeProperties.OnMoveePropsCreation += AssignMove;
    }

    private void OnDisable(){
        MoveeProperties.OnMoveePropsCreation -= AssignMove;
    }

    //References Mother Move Point and Parent Move Point to a MoveeProperties object.
    private void AssignMove(MoveeProperties unit){
        Debug.Log("I make my own day everydfay");
        unit.MotherMovePoint = motherMovePoint;
        unit.ParentMovePoint = parentMovePoint;
    }

}
