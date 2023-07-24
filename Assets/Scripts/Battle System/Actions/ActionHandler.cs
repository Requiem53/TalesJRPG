using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionHandler : MonoBehaviour
{
    [SerializeField] private BattleSystem BattleSystem;
    public static event Action<Actions> OnActionDecide;

    public void MeleeAttack()
    {
        OnActionDecide?.Invoke(new MeleeAttack(BattleSystem));
    }
    
}
