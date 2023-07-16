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
        BattleSystem.SetDialogue(BattleSystem.Enemy[0].Stats.CharInfo.Name + " attacks you!");

        yield return new WaitForSeconds(1f);

        bool isDead = BattleSystem.Player[0].Stats.TakeDamage(BattleSystem.Enemy[0].Stats.Damage);

        BattleSystem.Player[0].SetHUD();

        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            BattleSystem.SetState(new Lost(BattleSystem));
        }else
        {
            BattleSystem.SetState(new PlayerTurn(BattleSystem));
        }

    }
}