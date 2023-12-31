using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleState
{
    protected BattleSystem BattleSystem;
    public BattleState(BattleSystem battleSystem)
    {
        BattleSystem = battleSystem;
    }

    protected BattleTurnOrder BattleTurn{get => BattleSystem.Turn;}
    protected int TurnNumber{get => BattleSystem.Turn.TurnNumber;}
    protected Stats Battler{get => BattleSystem.Turn.TurnOrder[TurnNumber];}

    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual IEnumerator CastSpell(Spells spell, Stats target)
    {
        yield break;
    }

    public virtual IEnumerator Attack(Stats target)
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
        if(!LastTurn())
        {
            BattleSystem.Turn.TurnNumber++;
        }
        
    }

    protected bool LastTurn()
    {
        if(BattleSystem.Turn.TurnOrder.Count - 1 == TurnNumber)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Temporary
    protected bool IsDead()
    {
        return false;
    }

    protected void ResetTurn()
    {
        BattleSystem.Turn.TurnNumber = 0;
        BattleTurn.SortSpeed();
    }

    protected void NextTurn()
    {
        if(LastTurn())
            {
                BattleSystem.SetState(new TurnWrap(BattleSystem));
            }
            else
            {
                IncrementTurn();
                BattleSystem.SetState(new Turn(BattleSystem));          
            }
    }

}
