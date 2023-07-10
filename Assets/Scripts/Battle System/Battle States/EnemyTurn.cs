using System.Collections;
using UnityEngine;

internal class EnemyTurn : BattleState
{
    public EnemyTurn(BattleSystem battleSystem) : base(battleSystem)
    {
    }

    public override IEnumerator Start()
    {
        BattleSystem.SetDialogue(BattleSystem.EnemyStats.CharInfo.Name + " attacks you!");

        yield return new WaitForSeconds(1f);

        bool isDead = BattleSystem.PlayerStats.TakeDamage(BattleSystem.EnemyStats.Damage);

        BattleSystem.PlayerHUD.SetHUD(BattleSystem.PlayerStats);

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