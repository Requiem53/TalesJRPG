using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSummon
{
    public static void SummonCharacters(List<BattleHUD> characters, Transform battleStation)
    {
        for(int i = 0; i < characters.Count; i++)
        {
            if(characters[i] != null)
            {
                characters[i].Stats.gameObject.SetActive(true); 
                characters[i].Stats.transform.SetParent(battleStation, true);
            }
            
        } 
    }


}
