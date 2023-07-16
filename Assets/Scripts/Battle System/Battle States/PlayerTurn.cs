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
        bool isDead = BattleSystem.Enemy[0].Stats.TakeDamage(BattleSystem.Player[0].Stats.Damage);

        BattleSystem.SetDialogue(BattleSystem.Player[0].Stats.CharInfo.Name + " attacked " + BattleSystem.Enemy[0].Stats.CharInfo.Name + "!");

        BattleSystem.Enemy[0].SetHUD();

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
        BattleSystem.Player[0].Stats.Heal(10);
        BattleSystem.SetDialogue(BattleSystem.Player[0].Stats.CharInfo.Name + " healed themselves!");

        BattleSystem.Player[0].SetHUD();
        yield return new WaitForSeconds(1f);

        BattleSystem.SetState(new EnemyTurn(BattleSystem));
    }



    
}