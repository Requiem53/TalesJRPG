using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCompare : IComparer<BattleHUD>
{
    public int Compare(BattleHUD x, BattleHUD y)
    {
        if(x.Stats.Speed <= y.Stats.Speed)
        {
            return 1;
        }
        if(x.Stats.Speed >= y.Stats.Speed)
        {
            return -1;
        }
        
        return 0;
    }

}

