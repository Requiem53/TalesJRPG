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
        //TURN ON STATS should be here
        ResetTurn();
        BattleSystem.SetDialogue("A wild " + BattleSystem.Enemy[0].Stats.CharInfo.Name + " approaches....");
        BattleHUDHandler.InitializeHUDS(BattleSystem.Player);
        BattleHUDHandler.InitializeHUDS(BattleSystem.Enemy);

        yield return new WaitForSeconds(1f);

        BattleSystem.SetState(new Turn(BattleSystem));
    }

    
}
