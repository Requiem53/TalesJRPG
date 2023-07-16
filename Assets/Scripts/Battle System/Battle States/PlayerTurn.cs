using System.Collections;
using UnityEngine;

internal class PlayerTurn : BattleState
{
    public PlayerTurn(BattleSystem battleSystem) : base(battleSystem)
    {
    }

    public override IEnumerator Start()
    {
        BattleSystem.SetDialogue("What will " + Battler.CharInfo.Name + " do?");
        yield break;
    }

    public override IEnumerator Attack()
    {
        bool isDead = BattleSystem.Enemy[0].Stats.TakeDamage(Battler.Damage);

        BattleSystem.SetDialogue(Battler.CharInfo.Name + " attacked " + BattleSystem.Enemy[0].Stats.CharInfo.Name + "!");

        BattleSystem.Enemy[0].SetHUD();
    
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

    public override IEnumerator Heal()
    {
        Battler.Heal(10);
        BattleSystem.SetDialogue(Battler.CharInfo.Name + " healed themselves!");

        //Change soon to be consistent with everything
        BattlerHUD.SetHUD();
        yield return new WaitForSeconds(1f);

        NextTurn();
    }





    
}