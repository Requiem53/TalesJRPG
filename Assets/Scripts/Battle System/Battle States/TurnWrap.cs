using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnWrap : BattleState
{
    public TurnWrap(BattleSystem battleSystem) : base(battleSystem)
    {
    }
    //I DUNNO WHATS BREAKING THIS BUT WHATEVER. DISREGARDED
    public override IEnumerator Start()
    {
        ResetTurn();
        BattleSystem.SetState(new Turn(BattleSystem));
        yield break;
           
    }
}
