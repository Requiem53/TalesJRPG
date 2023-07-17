using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : BattleState
{
    public Turn(BattleSystem battleSystem) : base(battleSystem)
    {
    }

    public override IEnumerator Start()
    {
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
