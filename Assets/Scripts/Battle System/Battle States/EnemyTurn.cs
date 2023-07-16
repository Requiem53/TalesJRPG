using System.Collections;
using UnityEngine;

internal class EnemyTurn : BattleState
{
    public EnemyTurn(BattleSystem battleSystem) : base(battleSystem)
    {
    }

    public override IEnumerator Start()
    {
        //This be temporary fixes
        BattleSystem.SetDialogue(Battler.CharInfo.Name + " attacks you!");

        bool isDead = BattleSystem.Player[0].Stats.TakeDamage(Battler.Damage);

        BattleSystem.Player[0].SetHUD();

        yield return new WaitForSeconds(1f); 

        if(isDead)
        {
            BattleSystem.SetState(new Lost(BattleSystem));
        }
        else
        {
            NextTurn();
        }

    }
}