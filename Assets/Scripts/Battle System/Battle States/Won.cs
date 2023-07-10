using System.Collections;

internal class Won : BattleState
{
    public Won(BattleSystem battleSystem) : base(battleSystem)
    {
    }

    public override IEnumerator Start()
    {
        BattleSystem.SetDialogue("You win!");
        yield break;
    }
}