using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCompare : IComparer<Stats>
{
    public int Compare(Stats x, Stats y)
    {
        if(x.Speed <= y.Speed)
        {
            return 1;
        }
        if(x.Speed >= y.Speed)
        {
            return -1;
        }
        
        return 0;
    }

}
