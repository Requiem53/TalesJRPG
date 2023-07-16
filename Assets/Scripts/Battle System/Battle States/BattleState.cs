using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleState
{
    protected BattleSystem BattleSystem;

    protected int TurnNumber{get => BattleSystem.Turn.TurnNumber;}
    protected Stats Battler{get => BattleSystem.Turn.TurnOrder[TurnNumber];}
    //protected CharacterInfo AttackerInfo{get => Battler.CharInfo;}

    public BattleState(BattleSystem battleSystem)
    {
        BattleSystem = battleSystem;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual IEnumerator Attack()
    {
        yield break;
    }

    public virtual IEnumerator Heal()
    {
        yield break;
    }

    public virtual IEnumerator End()
    {
        yield break;
    }


    protected void IncrementTurn()
    {
        if(BattleSystem.Turn.TurnOrder.Count - 1 == TurnNumber)
        {
            BattleSystem.Turn.TurnNumber = 0;
        }
        else
        {
            BattleSystem.Turn.TurnNumber++;
        }
        
    }

    protected bool IsPlayable()
    {
        if(BattleSystem.Turn.TurnOrder[BattleSystem.Turn.TurnNumber].IsPlayable)
        {
            return true;
        }

        return false;
    }

}
