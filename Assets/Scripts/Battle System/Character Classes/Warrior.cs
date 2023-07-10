using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : CharacterClass
{
    //Change soon
    public override void InitializeClass()
    {
        Class = "Warrior";

        Strength = 10 * Stats.CharInfo.Level;
        Resilience = 10 * Stats.CharInfo.Level;
        Agility = 6 * Stats.CharInfo.Level;
        Wisdom = 4 * Stats.CharInfo.Level;
        Luck = 4 * Stats.CharInfo.Level;

    }

    public override void LevelUp()
    {
        Stats.CharInfo.Level++;
        
        Strength += 5;
        Resilience += 5;
        Agility += 3;
        Wisdom += 1;
        Luck += 1;

        StatsSetter();
    }

}
