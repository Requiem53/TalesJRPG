using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherMovePointReference : MonoBehaviour
{
   [SerializeField] private GameObject motherMovePoint;
   [SerializeField] private GameObject parentMovePoint;

   public GameObject MotherMovePoint{
        get{return motherMovePoint;}
        set{motherMovePoint = value;}
    }

    public GameObject ParentMovePoint{
        get{return parentMovePoint;}
        set{parentMovePoint = value;}
    }
}
