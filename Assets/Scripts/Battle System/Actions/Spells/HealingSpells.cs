using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Healing Spell", menuName = "Healing Spells")]
public class HealingSpells : Spells
{
    [SerializeField] private int _healAmount;

    protected Stats Target;
    public HealingSpells(Stats target)
    {
        Target = target;
    }

    public override void Start()
    {
        Heal(Target);
    }

    public override void Heal(Stats target)
    {
        target.Heal(_healAmount);
    }


}
