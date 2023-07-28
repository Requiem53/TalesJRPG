using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : BattleState
{
    public static event Action OnStartTurn;

    public Turn(BattleSystem battleSystem) : base(battleSystem)
    {
    }

    public override IEnumerator Start()
    {
        OnStartTurn?.Invoke();
        if(BattleSystem.Battler.IsPlayable)
        {   
            BattleSystem.SetState(new PlayerTurn(BattleSystem));
        }
        else
        {
            BattleSystem.SetState(new EnemyTurn(BattleSystem));
        }
        
        yield break;
    }
}
