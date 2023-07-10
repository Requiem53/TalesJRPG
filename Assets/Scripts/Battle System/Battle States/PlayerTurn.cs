using System.Collections;
using UnityEngine;

internal class PlayerTurn : BattleState
{
    public PlayerTurn(BattleSystem battleSystem) : base(battleSystem)
    {
    }

    public override IEnumerator Start()
    {
        BattleSystem.DialogueText.text = "Choose an action.";
        yield break;
    }

    public override IEnumerator Attack()
    {
        bool isDead = BattleSystem.EnemyStats.TakeDamage(BattleSystem.PlayerStats.Damage);

        BattleSystem.SetDialogue(BattleSystem.PlayerStats.CharInfo.Name + " attacked " + BattleSystem.EnemyStats.CharInfo.Name + "!");

        BattleSystem.EnemyHUD.SetHUD(BattleSystem.EnemyStats);

        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            BattleSystem.SetState(new Won(BattleSystem));
        }else
        {
            BattleSystem.SetState(new EnemyTurn(BattleSystem));
        }
    }

    public override IEnumerator Heal()
    {
        BattleSystem.PlayerStats.Heal(10);
        BattleSystem.SetDialogue(BattleSystem.PlayerStats.CharInfo.Name + " healed themselves!");

        BattleSystem.PlayerHUD.SetHUD(BattleSystem.PlayerStats);
        yield return new WaitForSeconds(1f);

        BattleSystem.SetState(new EnemyTurn(BattleSystem));
    }



    
}