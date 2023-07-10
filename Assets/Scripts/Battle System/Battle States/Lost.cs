using System.Collections;

internal class Lost : BattleState
{
    public Lost(BattleSystem battleSystem) : base(battleSystem)
    {
    }

    public override IEnumerator Start()
    {
        BattleSystem.SetDialogue("You lost..");
        yield break;
    }
}