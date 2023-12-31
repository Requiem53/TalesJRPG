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

    public override IEnumerator CastSpell(Spells spell, Stats target)
    {
        Battler.CastSpell(spell);
        yield break;
    }

    public override IEnumerator Attack(Stats target)
    {
        target.TakeDamage(Battler.Damage);
        BattleSystem.SetDialogue(Battler.CharInfo.Name + " attacked " + target.CharInfo.Name + "!");
    
        yield return new WaitForSeconds(1f);

        if(IsDead())
        {
            BattleSystem.SetState(new Won(BattleSystem));
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
        yield return new WaitForSeconds(1f);

        NextTurn();
    }





    
}