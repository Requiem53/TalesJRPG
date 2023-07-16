using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHUDHandler : MonoBehaviour
{
    public static void InitializeHUDS(List<BattleHUD> battleHUD)
    {
        for(int i = 0; i < battleHUD.Count; i++)
        {
            battleHUD[i].SetHUD();
        }
    }
}
