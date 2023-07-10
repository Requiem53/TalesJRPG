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
        BattleSystem.SetDialogue("A wild " + BattleSystem.EnemyStats.CharInfo.Name + " approaches....");

        BattleSystem.PlayerHUD.SetHUD(BattleSystem.PlayerStats);
        BattleSystem.EnemyHUD.SetHUD(BattleSystem.EnemyStats);

        yield return new WaitForSeconds(1f);

        BattleSystem.SetState(new PlayerTurn(BattleSystem));
    }

    
}
