using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AssignMotherMoveToMovee : MonoBehaviour
{
   [SerializeField] private GameObject motherMovePoint;
   [SerializeField] private GameObject parentMovePoint;

    private void OnEnable(){
        MoveeProperties.OnCreation += AssignMove;
    }

    private void OnDisable(){
        MoveeProperties.OnCreation -= AssignMove;
    }

    private void AssignMove(MoveeProperties unit){
        Debug.Log("I make my own day everydfay");
        unit.MotherMovePoint = motherMovePoint;
        unit.ParentMovePoint = parentMovePoint;
    }

}
