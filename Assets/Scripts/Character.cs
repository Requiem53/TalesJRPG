using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MoveeProperties
{
    private MoveeProperties unitProps;
    
    public MoveeProperties UnitProps{
        get{return unitProps;}
        set{unitProps = value;}
    }
}
