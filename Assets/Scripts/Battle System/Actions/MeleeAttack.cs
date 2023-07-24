using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Actions
{
    public void Start()
    {
        MeleeStrike(Target);
    }

    protected Stats Target;

    public MeleeAttack(Stats target)
    {
        Target = target;
    }

    public void MeleeStrike(Stats target)
    {
        //target.TakeDamage();
    }
}
