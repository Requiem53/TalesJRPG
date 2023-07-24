using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Actions
{
    protected BattleSystem BattleSystem;

    public MeleeAttack(BattleSystem battleSystem)
    {
        BattleSystem = battleSystem;
    }

    public void StartTarget(Stats target)
    {
        BattleSystem.OnMeleeAttackButton(target);
    }
}
