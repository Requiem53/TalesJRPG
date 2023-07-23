using System.Collections;
using UnityEngine;

internal class EnemyTurn : BattleState
{
    public EnemyTurn(BattleSystem battleSystem) : base(battleSystem)
    {
    }

    public override IEnumerator Start()
    {
        int target = Random.Range(0, BattleSystem.Player.Count);
        //This be temporary fixes
        BattleSystem.SetDialogue(Battler.CharInfo.Name + " attacks " + BattleSystem.Player[target].CharInfo.Name + "!");
        BattleSystem.Player[target].TakeDamage(Battler.Damage);

        yield return new WaitForSeconds(1f); 

        if(IsDead())
        {
            BattleSystem.SetState(new Lost(BattleSystem));
        }
        else
        {
            NextTurn();
        }

    }
}