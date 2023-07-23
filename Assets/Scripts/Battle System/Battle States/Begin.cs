using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Begin : BattleState
{
    public Begin(BattleSystem battleSystem) : base(battleSystem)
    {
    }

    public override IEnumerator Start()
    {    
        ResetTurn();
        BattleSystem.SetDialogue("A wild " + BattleSystem.Enemy[0].CharInfo.Name + " approaches....");

        yield return new WaitForSeconds(1f);

        BattleSystem.SetState(new Turn(BattleSystem));
    }

    
}
