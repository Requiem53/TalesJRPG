using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleSelect
{
    Off,
    Allies,
    Enemies,
    Spells
}
public class ActionSubMenu : MonoBehaviour
{
    public static event Action<BattleSelect> OnTargetsOn;

    public void DisplayOff()
    {
        OnTargetsOn?.Invoke(BattleSelect.Off);
    }

    public void DisplayAllies()
    {
        OnTargetsOn?.Invoke(BattleSelect.Allies);
    }

    public void DisplayEnemies()
    {
        OnTargetsOn?.Invoke(BattleSelect.Enemies);
    }

    public void DisplaySpells()
    {
        OnTargetsOn?.Invoke(BattleSelect.Spells);
    }
}
