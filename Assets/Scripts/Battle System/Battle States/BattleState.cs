using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleState
{
    protected BattleSystem BattleSystem;

    protected BattleTurnOrder BattleTurn{get => BattleSystem.Turn;}
    protected int TurnNumber{get => BattleSystem.Turn.TurnNumber;}
    protected BattleHUD BattlerHUD{get => BattleSystem.Turn.TurnOrder[TurnNumber];}
    protected Stats Battler{get => BattlerHUD.Stats;}
    //protected BattleHUD{get => BattleSystem.BattleHUD}

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
        if(!LastTurn())
        {
            BattleSystem.Turn.TurnNumber++;
        }
        
    }

    protected bool IsPlayable()
    {
        if(Battler.IsPlayable)
        {
            return true;
        }

        return false;
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
