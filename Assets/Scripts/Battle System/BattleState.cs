using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleState
{
    protected BattleSystem BattleSystem;

    public BattleState(BattleSystem battleSystem)
    {
        BattleSystem = battleSystem;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual IEnumerator Attack()
    {
        yield break;
    }

    public virtual IEnumerator Heal()
    {
        yield break;
    }

}
